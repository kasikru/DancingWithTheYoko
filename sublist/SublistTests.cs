using System.Collections.Generic;
using Xunit;

public class SublistTests
{
    [Fact]
    public void Empty_lists()
    {
        Assert.Equal(SublistType.Equal, Sublist.Classify(new List<int>(), new List<int>()));
    }

    [Fact]
    public void Empty_list_within_non_empty_list()
    {
        Assert.Equal(SublistType.Sublist, Sublist.Classify(new List<int>(), new List<int> { 1, 2, 3 }));
    }

    [Fact]
    public void Non_empty_list_contains_empty_list()
    {
        Assert.Equal(SublistType.Superlist, Sublist.Classify(new List<int> { 1, 2, 3 }, new List<int>()));
    }

    [Fact]
    public void List_equals_itself()
    {
        Assert.Equal(SublistType.Equal, Sublist.Classify(new List<int> { 1, 2, 3 }, new List<int> { 1, 2, 3 }));
    }

    [Fact]
    public void Different_lists()
    {
        Assert.Equal(SublistType.Unequal, Sublist.Classify(new List<int> { 1, 2, 3 }, new List<int> { 2, 3, 4 }));
    }

    [Fact]
    public void False_start()
    {
        Assert.Equal(SublistType.Sublist, Sublist.Classify(new List<int> { 1, 2, 5 }, new List<int> { 0, 1, 2, 3, 1, 2, 5, 6 }));
    }

    [Fact]
    public void Consecutive()
    {
        Assert.Equal(SublistType.Sublist, Sublist.Classify(new List<int> { 1, 1, 2 }, new List<int> { 0, 1, 1, 1, 2, 1, 2 }));
    }

    [Fact]
    public void Sublist_at_start()
    {
        Assert.Equal(SublistType.Sublist, Sublist.Classify(new List<int> { 0, 1, 2 }, new List<int> { 0, 1, 2, 3, 4, 5 }));
    }

    [Fact]
    public void Sublist_in_middle()
    {
        Assert.Equal(SublistType.Sublist, Sublist.Classify(new List<int> { 2, 3, 4 }, new List<int> { 0, 1, 2, 3, 4, 5 }));
    }

    [Fact]
    public void Sublist_at_end()
    {
        Assert.Equal(SublistType.Sublist, Sublist.Classify(new List<int> { 3, 4, 5 }, new List<int> { 0, 1, 2, 3, 4, 5 }));
    }

    [Fact]
    public void At_start_of_superlist()
    {
        Assert.Equal(SublistType.Superlist, Sublist.Classify(new List<int> { 0, 1, 2, 3, 4, 5 }, new List<int> { 0, 1, 2 }));
    }

    [Fact]
    public void In_middle_of_superlist()
    {
        Assert.Equal(SublistType.Superlist, Sublist.Classify(new List<int> { 0, 1, 2, 3, 4, 5 }, new List<int> { 2, 3 }));
    }

    [Fact]
    public void At_end_of_superlist()
    {
        Assert.Equal(SublistType.Superlist, Sublist.Classify(new List<int> { 0, 1, 2, 3, 4, 5 }, new List<int> { 3, 4, 5 }));
    }

    [Fact]
    public void First_list_missing_element_from_second_list()
    {
        Assert.Equal(SublistType.Unequal, Sublist.Classify(new List<int> { 1, 3 }, new List<int> { 1, 2, 3 }));
    }

    [Fact]
    public void Second_list_missing_element_from_first_list()
    {
        Assert.Equal(SublistType.Unequal, Sublist.Classify(new List<int> { 1, 2, 3 }, new List<int> { 1, 3 }));
    }

    [Fact]
    public void First_list_missing_additional_digits_from_second_list()
    {
        Assert.Equal(SublistType.Unequal, Sublist.Classify(new List<int> { 1, 2 }, new List<int> { 1, 22 }));
    }

    [Fact]
    public void Order_matters_to_a_list()
    {
        Assert.Equal(SublistType.Unequal, Sublist.Classify(new List<int> { 1, 2, 3 }, new List<int> { 3, 2, 1 }));
    }

    [Fact]
    public void Same_digits_but_different_numbers()
    {
        Assert.Equal(SublistType.Unequal, Sublist.Classify(new List<int> { 1, 0, 1 }, new List<int> { 10, 1 }));
    }
}

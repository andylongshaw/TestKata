using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xunit;

namespace Word_frequency_spec
{
    public class A_string_with_no_words
    {
        private readonly Calculator _calculator = new Calculator();

        [Fact]
        public void Produces_an_empty_list()
        {
            Assert.Empty(_calculator.CalculateFrequency(""));
        }
    }

    public class A_string_containing_a_single_word
    {
        [Fact]
        public void Produces_a_list_with_a_single_entry_and_a_word_count_of_one()
        {
            var list = new Calculator().CalculateFrequency("Hello");
            Assert.Equal(1, list.Count);
            Assert.Equal(1, list["Hello"]);
        }
    }


    public class A_string_containing_only_unique_words
    {
        [Fact]
        public void Produces_a_list_with_multiple_entries_each_with_a_word_count_of_one()
        {
            var list = new Calculator().CalculateFrequency("Hello world again");
            Assert.Equal(3, list.Count);
            foreach (int value in list.Values)
            {
                Assert.Equal(1, value);
            }
        }
    }

    public class A_string_containing_multiples_of_words
    {
        [Fact]
        public void Produces_a_list_with_entries_that_have_a_word_count_of_more_than_one()
        {
            var list = new Calculator().CalculateFrequency("hello hello its good to be back its good to be back");
            Assert.Equal(6, list.Count);
            foreach (int value in list.Values)
            {
                Assert.Equal(2, value);
            }
        }
    }

    public class Calculator
    {
        public Dictionary<string, int> CalculateFrequency(string words)
        {
            var frequencyList = new Dictionary<string, int>();

            var keys = words.Split(' ');

            foreach (string key in keys)
            {
                if (key.Trim().Length != 0)
                {
                    var cleanKey = key.Trim();
                    if (frequencyList.ContainsKey(cleanKey))
                    {
                        frequencyList[key] += 1;
                    }
                    else
                    {

                        frequencyList.Add(key, 1);
                    }
                }
            }

            return frequencyList;
        }
    }
}

using System;
using Xunit;

namespace StringCalculator_spec
{
    public class An_empty_string
    {
        private readonly string _numberString = "";

        [Fact]
        public void Gives_a_sum_of_zero()
        {
            Assert.Equal(0, new StringCalculator().Add(_numberString));
        }
    }

    public class A_single_number
    {
        private readonly string _numberString = "3";

        [Fact]
        public void Gives_a_sum_of_itself()
        {
            Assert.Equal(3, new StringCalculator().Add(_numberString));
        }
    }

    public class Two_numbers_separated_by_a_comma
    {
        private readonly string _numbers = "1,1";

        [Fact]
        public void Gives_the_sum_of_the_two_numbers()
        {
            Assert.Equal(2, new StringCalculator().Add(_numbers));
        }
    }

    public class StringCalculator
    {
        public int Add(string numberString)
        {
            var numbersAsStrings = numberString.Split(',');
            var total = 0;

            foreach (string numberAsAString in numbersAsStrings)
            {
                int number;
                Int32.TryParse(numberAsAString, out number);
                total += number;
            }

            return total;
        }
    }
}

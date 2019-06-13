using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Murach.Validation
{   /// <summary>
/// This is a Validator class that test for valid data
/// if data is present, if it is an integer, if it is within range, is a valid email
/// </summary>
    public static class Validator
	{
		private static string title = "Entry Error";
        /// <summary>
        /// This is a title constructor i.e getter and setter
        /// </summary>
		public static string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}
        /// <summary>
        /// This checks for textbox contents
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>True if there is something in the textbox </returns>
		public static bool IsPresent(TextBox textBox)
		{
			if (textBox.Text == "")
			{
				MessageBox.Show(textBox.Tag + " is a required field.", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}
        /// <summary>
        /// This tests for decimal value within text box
        /// </summary>
        /// <param name="textBox">any textbox</param>
        /// <returns>true if content is a decimal</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            decimal number = 0m;
            if (Decimal.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be a decimal value.", Title);
                textBox.Focus();
                return false;
            }
        }
        
        public static bool IsInt32(TextBox textBox)
        {
            int number = 0;
            if (Int32.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

		public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
		{
			decimal number = Convert.ToDecimal(textBox.Text);
			if (number < min || number > max)
			{
				MessageBox.Show(textBox.Tag + " must be between " + min
					+ " and " + max + ".", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}
        /// <summary>
        /// Validates valid email formats
        /// </summary>
        /// <param name="textBox"></param>
        /// <returns>True if email is valid</returns>
        public static bool IsValidEmail(TextBox textBox)
        {
            if (textBox.Text.IndexOf("@") == -1 ||
                 textBox.Text.IndexOf(".") == -1)
            {
                MessageBox.Show(textBox.Tag + " must be a valid email address.",
                    Title);
                textBox.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MijnDatastructuren;

namespace MijnAlgoritmen
{
	public class Les2
	{
		public static bool CheckBrackets(String s)
		{
			MijnDatastructuren.Stack<string> stack = new MijnDatastructuren.Stack<string>();

			char[] charArr = s.ToCharArray();

			for (int i = 0; i < charArr.Length; i++)
			{
				string b = charArr[i].ToString();

				bool opening = (b == "(" || b == "[");
				bool closing = (b == ")" || b == "]");

				if ( opening)
					stack.Push(b);
				else if (closing)
				{
					if (stack.Length == 0) return false;
					else
					{
						string c = stack.Pop();
						if (b == ")" && c != "(") return false;
						else if (b == "]" && c != "[") return false;
					}
				}
			}
			
			return s.Length % 2 == 0;
		}

		public static bool CheckBrackets2(string s)
		{
			if (s.Length % 2 == 1)
				return false;
			else
			{
				MijnDatastructuren.Stack<string> stack = new MijnDatastructuren.Stack<string>();
				int closing = 0;
				int opening = 0;
				char[] charArr = s.ToCharArray();

				for (int i = 0; i < charArr.Length; i++)
				{
					string b = charArr[i].ToString();

					if (b == "]" || b == ")")
						closing++;
					else if (b == "[" || b == "(")
						opening++;

					stack.Push(b);
				}

				while (stack.Length != 0)
				{
					string previous = "";
					while (stack.Length != 0)
					{
						string b = stack.Pop();
						if (previous == "]")
						{
							if (b == "(")
								return false;
						}
						if (previous == ")")
						{
							if (b == "[")
								return false;
						}
						if (previous == "(")
						{
							if (b == "]")
								return false;
						}
						if (previous == "[")
						{
							if (b == ")")
								return false;
						}
						previous = b;
					}
				}
				return opening == closing;
			}
		}
	}
}

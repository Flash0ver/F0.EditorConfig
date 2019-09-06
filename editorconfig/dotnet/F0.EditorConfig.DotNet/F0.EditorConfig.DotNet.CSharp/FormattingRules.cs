// dotnet_sort_system_directives_first
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Octokit;

namespace F0.EditorConfig.DotNet.CSharp
{
	public class FormattingRules
	{
	}

	internal class OrganizeUsings
	{
		public async Task GetGitHubUserInfoAsync()
		{
			const string userAgent = "Flash0ver";
			const string loginName = "Flash0ver";

			var github = new GitHubClient(new ProductHeaderValue(userAgent));
			User user = await github.User.Get(loginName);

			Console.WriteLine($"{user.Followers} folks follow {loginName}!");
		}
	}

	internal class NewlineOptions
	{
		// csharp_new_line_before_open_brace
		private void MyMethod()
		{
			if (true)
			{

			}
		}

		public NewlineOptions(bool boolean, IEnumerable<int> e)
		{
			// csharp_new_line_before_else
			if (boolean)
			{

			}
			else
			{

			}

			// csharp_new_line_before_catch
			try
			{
				throw new Exception();
			}
			catch (Exception ex)
			{
				ExceptionDispatchInfo.Capture(ex).Throw();
			}

			// csharp_new_line_before_finally
			try
			{
				throw new Exception();
			}
			catch (Exception ex)
			{
				ExceptionDispatchInfo.Capture(ex).Throw();
			}
			finally
			{
				Console.WriteLine();
			}

			// csharp_new_line_before_members_in_object_initializers
			var z = new A()
			{
				B = 3,
				C = 4
			};


			// csharp_new_line_before_members_in_anonymous_types
			var y = new
			{
				A = 3,
				B = 4
			};

			// csharp_new_line_between_query_expression_clauses
			IEnumerable<int> q = from a in e
								 from b in e
								 select a * b;
		}

		private class A
		{
			public A()
			{
			}

			public int B
			{
				get; set;
			}
			public int C
			{
				get; set;
			}
		}
	}

	internal class IndentationOptions
	{
		public IndentationOptions(Color c)
		{
			// csharp_indent_case_contents
			// csharp_indent_switch_labels
			switch (c)
			{
				case Color.Red:
					Console.WriteLine("The color is red");
					break;
				case Color.Blue:
					Console.WriteLine("The color is blue");
					break;
				default:
					Console.WriteLine("The color is unknown.");
					break;
			}
		}

		// csharp_indent_labels
		private class C
		{
			private string MyMethod(bool boolean)
			{
				if (boolean)
				{
					goto error;
				}
			error:
				throw new Exception();
			}
		}

		public enum Color
		{
			Red,
			Green,
			Blue
		}
	}

	internal class SpacingOptions
	{
		public SpacingOptions(long x)
		{
			// csharp_space_after_cast
			int y = (int)x;

			// csharp_space_after_keywords_in_control_flow_statements
			for (int i = 0; i < x; i++)
			{
			}

			// csharp_space_between_parentheses
			for (int i = 0; i < 10; i++)
			{
			}
		}

		// csharp_space_before_colon_in_inheritance_clause
		// csharp_space_after_colon_in_inheritance_clause
		private interface I
		{

		}

		private class C : I
		{

		}

		private int Method(int x, int y)
		{
			// csharp_space_around_binary_operators
			return x * (x - y);
		}

		// csharp_space_between_method_declaration_parameter_list_parentheses
		private void Bark(int x)
		{
		}


		// csharp_space_between_method_declaration_empty_parameter_list_parentheses
		// csharp_space_between_method_call_empty_parameter_list_parentheses
		// csharp_space_between_method_call_name_and_opening_parenthesis
		private void Goo()
		{
			Goo(1);
		}

		private void Goo(int x)
		{
			Goo();
		}

		private void Method(int argument, long x, long y)
		{
			// csharp_space_between_method_call_parameter_list_parentheses
			MyMethod(argument);

			long z = (x * y) - ((y - x) * 3);

			int w = (int)x;

		}


		private void MyMethod(object argument)
		{
			throw new NotImplementedException();
		}
	}

	internal class WrappingOptions
	{
		public WrappingOptions()
		{
			//csharp_preserve_single_line_statements
			int i = 0;
			string name = "John";

			Console.WriteLine($"{i}:{name}");
		}

		//csharp_preserve_single_line_blocks
		public int Foo { get; set; }

		public int MyProperty
		{
			get; set;
		}
	}
}

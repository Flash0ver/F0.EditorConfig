// dotnet_sort_system_directives_first
// dotnet_separate_import_directive_groups
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Octokit;

// dotnet_style_namespace_match_folder
// csharp_style_namespace_declarations
namespace F0.EditorConfig.DotNet.CSharp;

public class FormattingRules
{
}

internal class OrganizeUsingDirectives
{
	public async Task GetGitHubUserInfoAsync()
	{
		const string userAgent = "Flash0ver";
		const string loginName = "Flash0ver";

		GitHubClient github = new(new ProductHeaderValue(userAgent));
		User user = await github.User.Get(loginName);

		Console.WriteLine($"{user.Followers} folks follow {loginName}!");
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
internal class NewlineOptions
{
	// csharp_new_line_before_open_brace
	internal void MyMethod()
	{
		if (true)
		{
			throw new InvalidOperationException();
		}
	}

	public NewlineOptions(bool boolean)
	{
		// csharp_new_line_before_else
		if (boolean)
		{
			Console.WriteLine();
		}
		else
		{
			throw new InvalidOperationException();
		}

		// csharp_new_line_before_catch
		try
		{
			throw new InvalidOperationException();
		}
		catch (Exception e)
		{
			ExceptionDispatchInfo.Capture(e).Throw();
		}

		// csharp_new_line_before_finally
		try
		{
			throw new InvalidOperationException();
		}
		catch (Exception e)
		{
			ExceptionDispatchInfo.Capture(e).Throw();
		}
		finally
		{
			Console.WriteLine();
		}
	}

	internal void Method(IEnumerable<int> e)
	{
		// csharp_new_line_before_members_in_object_initializers
		var z = new C()
		{
			A = 3,
			B = 4
		};


		// csharp_new_line_before_members_in_anonymous_types
		var y = new
		{
			A = 3,
			B = 4
		};

		// csharp_new_line_between_query_expression_clauses
		var q = from a in e
				from b in e
				select a * b;

		Console.WriteLine($"{z}{y}{q}");
	}

	private class C
	{
		public C()
		{
		}

		public int A
		{
			get; set;
		}
		public int B
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
	internal class C
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

		public C()
		{
			_ = MyMethod(true);
		}
	}

	public enum Color
	{
		Red,
		Green,
		Blue
	}

	// csharp_indent_block_contents
	// csharp_indent_braces
	internal static void Hello()
	{
		Console.WriteLine("Hello");
	}

	internal void Method(Color c)
	{
		switch (c)
		{
			// csharp_indent_case_contents_when_block
			case 0:
			{
				Console.WriteLine("Hello");
				break;
			}
		}
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
[SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
internal class SpacingOptions
{
	public SpacingOptions(long x)
	{
		// csharp_space_after_cast
		int y = (int)x;

		// csharp_space_after_keywords_in_control_flow_statements
		for (int i = 0; i < x; i++)
		{
			Console.WriteLine(i);
		}

		// csharp_space_between_parentheses
		for (int i = 0; i < 10; i++)
		{
			Console.WriteLine(i);
		}
		var z = (x * y) - ((y - x) * 3);
		int w = (int)x;

		Console.WriteLine($"{y}{z}{w}");
	}

	// csharp_space_before_colon_in_inheritance_clause
	// csharp_space_after_colon_in_inheritance_clause
	private interface I
	{

	}

	internal class C : I
	{

	}

	internal int Method(int x, int y)
	{
		// csharp_space_around_binary_operators
		return x * (x - y);
	}

	// csharp_space_between_method_declaration_parameter_list_parentheses
	internal void Bark(int x)
	{
		Console.WriteLine(x);
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

	// csharp_space_between_method_declaration_name_and_open_parenthesis
	internal void M() { }

	internal void Method(int argument)
	{
		// csharp_space_between_method_call_parameter_list_parentheses
		MyMethod(argument);
	}

	[SuppressMessage("Style", "IDE0003:Remove qualification", Justification = "<Pending>")]
	internal void MethodOne()
	{
		// csharp_space_after_comma
		// csharp_space_before_comma
		int[] x = new int[] { 1, 2, 3, 4, 5 };

		// csharp_space_after_dot
		// csharp_space_before_dot
		this.Goo();

		// csharp_space_after_semicolon_in_for_statement
		// csharp_space_before_semicolon_in_for_statement
		for (int i = 0; i < x.Length; i++)
		{ }
	}

	internal void MethodTwo()
	{
		// csharp_space_around_declaration_statements
		int x = 0;

		// csharp_space_before_open_square_brackets
		// csharp_space_between_empty_square_brackets
		int[] numbers = new int[] { 1, 2, 3, 4, 5 };

		// csharp_space_between_square_brackets
		int index = numbers[0];

		Console.WriteLine($"{x}{index}");
	}

	private void MyMethod(object argument)
	{
		throw new ArgumentException(argument.ToString(), nameof(argument));
	}
}

internal class WrapOptions
{
	public WrapOptions()
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

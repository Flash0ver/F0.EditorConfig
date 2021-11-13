// file_header_template
// csharp_using_directive_placement
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Timers;

namespace F0.EditorConfig.DotNet.CSharp;

public class CodeStyles
{
}

internal class ThisQualifiers
{
	public ThisQualifiers()
	{
		// dotnet_style_qualification_for_field
		capacity = 0;

		// dotnet_style_qualification_for_property
		ID = 0;

		// dotnet_style_qualification_for_method
		Display();

		// dotnet_style_qualification_for_event
		Elapsed += Handler;
	}

	private readonly int capacity;

	public int ID { get; private set; }

	private void Display()
	{
		Console.WriteLine(capacity);
	}

	public event ElapsedEventHandler Elapsed;

	private void Handler(object sender, ElapsedEventArgs e)
	{
		Elapsed?.Invoke(sender, e);
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
internal class LanguageKeywordsInsteadOfFrameworkTypeNamesForTypeReferences
{
	// dotnet_style_predefined_type_for_locals_parameters_members
	private int _member;

	public LanguageKeywordsInsteadOfFrameworkTypeNamesForTypeReferences()
	{
		// dotnet_style_predefined_type_for_member_access
		var local = Int32.MaxValue;

		Console.WriteLine(local);
	}

	internal void Method(int value)
	{
		_member = value;
	}

	internal void Method()
	{
		Console.WriteLine(_member);
	}
}

internal class ModifierPreferences
{
	// dotnet_style_require_accessibility_modifiers
	private const string thisFieldIsConst = "constant";

	internal class MyClass1
	{
		// csharp_preferred_modifier_order
		private static readonly int _daysInYear = 365;

		public int Method()
		{
			return _daysInYear;
		}
	}

	internal class MyClass2
	{
		// dotnet_style_readonly_field
		private readonly int _daysInYear = 365;

		public int Method()
		{
			return _daysInYear;
		}
	}

	public ModifierPreferences()
	{
		Console.WriteLine(thisFieldIsConst);
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
internal class ParenthesesPreferences
{
	public int Method(int a, int b, int c)
	{
		// dotnet_style_parentheses_in_arithmetic_binary_operators
		var v = a + (b * c);

		return v;
	}

	public bool Method(bool a, bool b, bool c)
	{
		// dotnet_style_parentheses_in_other_binary_operators
		var v = a || (b && c);

		return v;
	}

	public dynamic Method(dynamic a)
	{
		// dotnet_style_parentheses_in_other_operators
		var v = a.b.Length;

		return v;
	}

	public bool Method(int a, int b, int c, int d)
	{
		// dotnet_style_parentheses_in_relational_binary_operators
		var v = (a < b) == (c > d);

		return v;
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
internal class ExpressionLevelPreferences
{
	public ExpressionLevelPreferences()
	{
		// dotnet_style_object_initializer
		var c = new Customer() { Age = 21 };

		// dotnet_style_collection_initializer
		var list = new List<int> { 1, 2, 3 };

		// dotnet_style_explicit_tuple_names
		(string name, int age) customer = GetCustomer();
		var name = customer.name;

		// dotnet_style_prefer_inferred_tuple_names
		var tuple = (age, name);

		// dotnet_style_prefer_inferred_anonymous_type_member_names
		var anon = new { age, name };

		Console.WriteLine($"{c}{list}{tuple}{anon}{Age++}");
	}

	// dotnet_style_prefer_auto_properties
	private int Age { get; }

	public void Method(object value)
	{
		// dotnet_style_prefer_is_null_check_over_reference_equality_method
		if (value is null)
		{
			return;
		}
	}

	public string Method(bool expr)
	{
		// dotnet_style_prefer_conditional_expression_over_assignment
		string s = expr ? "hello" : "world";

		Console.WriteLine(s);

		// dotnet_style_prefer_conditional_expression_over_return
		return expr ? "hello" : "world";
	}

	public int Method(int x)
	{
		// dotnet_style_prefer_compound_assignment
		x += 1;

		return x;
	}

	public string Method(float someValue)
	{
		// dotnet_style_prefer_simplified_interpolation
		var str = $"prefix {someValue} suffix";

		return str;
	}

	public bool Method()
	{
		// dotnet_style_prefer_simplified_boolean_expressions
		var result1 = M1() && M2();
		var result2 = M1() || M2();

		return result1 && result2;
	}

	private class Customer
	{
		public Customer()
		{
		}

		public int Age { get; set; }
	}

	private (string name, int age) GetCustomer()
	{
		throw new NotImplementedException();
	}

	private readonly int age = default;

	private bool M1()
	{
		return false;
	}

	private bool M2()
	{
		return false;
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
internal class NullCheckingPreferences
{
	public object Method(object x, object y)
	{
		// dotnet_style_coalesce_expression
		var v = x ?? y;

		return v;
	}

	public object Method(object o)
	{
		// dotnet_style_null_propagation
		var v = o?.ToString();

		return v;
	}
}

[SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
internal class ParameterPreferences
{
	// dotnet_code_quality_unused_parameters
	public int GetNum1() { return 1; }
	internal int GetNum2() { return 1; }
	private int GetNum3() { return 1; }
}

[SuppressMessage("Style", "IDE0003:Remove qualification", Justification = "<Pending>")]
internal class ImplicitAndExplicitTypes
{
	public ImplicitAndExplicitTypes()
	{
		// csharp_style_var_for_built_in_types
		int x = 5;

		// csharp_style_var_when_type_is_apparent
		var obj = new Customer();

		// csharp_style_var_elsewhere
		bool f = this.Init();

		Console.WriteLine($"{x}{obj}{f}");
	}

	private class Customer
	{
		public Customer()
		{
		}
	}

	private bool Init()
	{
		throw new NotImplementedException();
	}
}

[SuppressMessage("Style", "IDE0003:Remove qualification", Justification = "<Pending>")]
[SuppressMessage("Style", "IDE0062:Make local function 'static'", Justification = "<Pending>")]
internal class ExpressionBodiedMembers<T>
{
	// csharp_style_expression_bodied_methods
	public int GetAge() { return this.Age; }

	internal class Customer
	{
		// csharp_style_expression_bodied_constructors
		public Customer(int age) { Age = age; }

		public int Age { get; }
	}

	public class ComplexNumber
	{
		public double Real { get; }
		public double Imaginary { get; }

		public ComplexNumber(double real, double imaginary)
		{
			Real = real;
			Imaginary = imaginary;
		}

		// csharp_style_expression_bodied_operators
		public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
		{ return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary); }
	}

	// csharp_style_expression_bodied_properties
	public int Age => _age;

	// csharp_style_expression_bodied_indexers
	public T this[int i] => _values[i];

	internal class Person
	{
		// csharp_style_expression_bodied_accessors
		public int Age { get => _age; set => _age = value; }

		private dynamic _age;
	}

	internal readonly int _age = default;
	private readonly T[] _values = default;

	[SuppressMessage("Style", "IDE0039:Use local function", Justification = "<Pending>")]
	internal Func<int, int> Method()
	{
		// csharp_style_expression_bodied_lambdas
		Func<int, int> square = x => x * x;

		return square;
	}


	// csharp_style_expression_bodied_local_functions
	internal void M()
	{
		Hello();
		void Hello()
		{
			Console.WriteLine("Hello");
		}
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
[SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value", Justification = "<Pending>")]
internal class PatternMatchingPreferences
{
	public PatternMatchingPreferences(object o)
	{
		// csharp_style_pattern_matching_over_is_with_cast_check
		if (o is int i)
		{
			Console.WriteLine(i);
		}

		// csharp_style_pattern_matching_over_as_with_null_check
		if (o is string s)
		{
			Console.WriteLine(s);
		}
	}

	public bool Method(int? i)
	{
		// csharp_style_prefer_pattern_matching
		var x = i is default(int) or > (default(int));

		return x;
	}

	public bool Method(object o)
	{
		// csharp_style_prefer_not_pattern
		var y = o is not C c;

		return y;
	}

	private class C
	{
	}
}

[SuppressMessage("Style", "IDE0049:Use framework type", Justification = "<Pending>")]
internal class InlinedVariableDeclarations
{
	public InlinedVariableDeclarations(string value)
	{
		// csharp_style_inlined_variable_declaration
		if (int.TryParse(value, out int i))
		{
			Console.WriteLine(i);
		}
	}
}

internal class CSharpExpressionLevelPreferences
{
	// csharp_prefer_simple_default_expression
	internal void DoWork(CancellationToken cancellationToken = default)
	{
		cancellationToken.ThrowIfCancellationRequested();
	}
}

internal class CSharpNullCheckingPreferences
{
	public CSharpNullCheckingPreferences(string s, Action<object> func, object args)
	{
		// csharp_style_throw_expression
		this.s = s ?? throw new ArgumentNullException(nameof(s));

		// csharp_style_conditional_delegate_call
		func?.Invoke(args);
	}

	private readonly string s;

	internal string Method()
	{
		return s;
	}
}

[SuppressMessage("Style", "IDE0003:Remove qualification", Justification = "<Pending>")]
internal class CodeBlockPreferences
{
	public CodeBlockPreferences(bool test)
	{
		// csharp_prefer_braces
		if (test)
		{ this.Display(); }
	}

	private void Display()
	{
		throw new NotImplementedException();
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
internal class UnusedValuePreferences
{
	public UnusedValuePreferences()
	{
		// csharp_style_unused_value_expression_statement_preference
		_ = System.Convert.ToInt32("35");
	}


	// csharp_style_unused_value_assignment_preference
	internal int GetCount(Dictionary<string, int> wordCount, string searchWord)
	{
		_ = wordCount.TryGetValue(searchWord, out var count);
		return count;
	}
}

internal class IndexAndRangePreferences
{
	[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
	internal static void Method()
	{
		// csharp_style_prefer_index_operator
		string[] names = { "Archimedes", "Pythagoras", "Euclid" };
		var index = names[^1];

		// csharp_style_prefer_range_operator
		string sentence = "the quick brown fox";
		var sub = sentence[0..^4];
	}
}

[SuppressMessage("Style", "IDE0008:Use explicit type", Justification = "<Pending>")]
internal class MiscellaneousPreferences
{
	public MiscellaneousPreferences()
	{
		// csharp_style_deconstructed_variable_declaration
		var (name, age) = GetPersonTuple();
		Console.WriteLine($"{name} {age}");

		(int x, int y) = GetPointTuple();
		Console.WriteLine($"{x} {y}");
	}

	private static (string name, int age) GetPersonTuple()
	{
		return ("Name", 42);
	}

	private static (int x, int y) GetPointTuple()
	{
		return (1, 2);
	}

	[SuppressMessage("Style", "IDE0062:Make local function 'static'", Justification = "<Pending>")]
	public int Fibonacci(int value)
	{
		return fibonacci(value);

		// csharp_style_pattern_local_over_anonymous_function
		int fibonacci(int n)
		{
			return n <= 1 ? 1 : fibonacci(n - 1) + fibonacci(n - 2);
		}
	}

	public bool Method()
	{
		// csharp_style_implicit_object_creation_when_type_is_apparent
		C c = new();
		C c2 = new() { Field = 0 };

		return c.Equals(c2);
	}

	// csharp_prefer_static_local_function
	internal void M()
	{
		Hello();
		static void Hello()
		{
			Console.WriteLine("Hello");
		}
	}

	internal static void Method(IDisposable b)
	{
		// csharp_prefer_simple_using_statement
		using var a = b;
	}

	internal static int Method(int x)
	{
		// csharp_style_prefer_switch_expression
		return x switch
		{
			1 => 1 * 1,
			2 => 2 * 2,
			_ => 0,
		};
	}

	private class C
	{
		internal int Field;
	}
}

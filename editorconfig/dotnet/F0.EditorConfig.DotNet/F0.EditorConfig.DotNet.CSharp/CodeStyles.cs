// csharp_using_directive_placement
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Timers;

namespace F0.EditorConfig.DotNet.CSharp
{
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

	internal class LanguageKeywordsInsteadOfFrameworkTypeNamesForTypeReferences
	{
		// dotnet_style_predefined_type_for_locals_parameters_members
		private int _member;

		public LanguageKeywordsInsteadOfFrameworkTypeNamesForTypeReferences()
		{
			// dotnet_style_predefined_type_for_member_access
			int local = Int32.MaxValue;

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

	internal class ParenthesesPreferences
	{
		public int Method(int a, int b, int c)
		{
			// dotnet_style_parentheses_in_arithmetic_binary_operators
			int v = a + (b * c);

			return v;
		}

		public bool Method(bool a, bool b, bool c)
		{
			// dotnet_style_parentheses_in_other_binary_operators
			bool v = a || (b && c);

			return v;
		}

		public dynamic Method(dynamic a)
		{
			// dotnet_style_parentheses_in_other_operators
			dynamic v = a.b.Length;

			return v;
		}

		public bool Method(int a, int b, int c, int d)
		{
			// dotnet_style_parentheses_in_relational_binary_operators
			bool v = (a < b) == (c > d);

			return v;
		}
	}

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
			string name = customer.name;

			// dotnet_style_prefer_inferred_tuple_names
			(int age, string name) tuple = (age, name);

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

			throw new InvalidOperationException();
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

		private readonly int age = 0;
	}

	internal class NullCheckingPreferences
	{
		public object Method(object x, object y)
		{
			// dotnet_style_coalesce_expression
			object v = x ?? y;

			return v;
		}

		public object Method(object o)
		{
			// dotnet_style_null_propagation
			string v = o?.ToString();

			return v;
		}
	}

	internal class ParameterPreferences
	{
		// dotnet_code_quality_unused_parameters
		public int GetNum() { return 1; }
	}

	internal class ImplicitAndExplicitTypes
	{
		public ImplicitAndExplicitTypes()
		{
			// csharp_style_var_for_built_in_types
			int x = 5;

			// csharp_style_var_when_type_is_apparent
			var obj = new Customer();

			// csharp_style_var_elsewhere
			bool f = Init();

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

	internal class ExpressionBodiedMembers<T>
	{
		// csharp_style_expression_bodied_methods
		public int GetAge() { return Age; }

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

		internal readonly int _age = 0;
		private readonly T[] _values = null;

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

	internal class PatternMatching
	{
		public PatternMatching(object o)
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
	}

	internal class InlinedVariableDeclarations
	{
		public InlinedVariableDeclarations(string value)
		{
			// csharp_style_inlined_variable_declaration
			if (Int32.TryParse(value, out int i))
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

	internal class CodeBlockPreferences
	{
		public CodeBlockPreferences(bool test)
		{
			// csharp_prefer_braces
			if (test)
			{ Display(); }
		}

		private void Display()
		{
			throw new NotImplementedException();
		}
	}

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
			_ = wordCount.TryGetValue(searchWord, out int count);
			return count;
		}
	}

	internal class MiscellaneousPreferences
	{
		public MiscellaneousPreferences()
		{
			// csharp_style_deconstructed_variable_declaration
			(string name, int age) = GetPersonTuple();
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

		public int Fibonacci(int value)
		{
			return fibonacci(value);

			// csharp_style_pattern_local_over_anonymous_function
			int fibonacci(int n)
			{
				return n <= 1 ? 1 : fibonacci(n - 1) + fibonacci(n - 2);
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace F0.EditorConfig.DotNet.CSharp.Code
{
	public class MyClass
	{
		public event EventHandler<MyEventArgs> RaiseEvent;

		public string this[int i] => list[i];

		private int myVar;
		public int MyProperty
		{
			get => myVar;
			set => SetField(ref myVar, value);
		}

		public float Property => Math.Abs(myField);

		private readonly float myField;

		private readonly List<string> list;

		public MyClass()
		{
			int zero = GetDefault<int>();
			myVar = zero;

			myField = Single.MinValue;
			MyProperty = Int32.MaxValue;
			Watch();
			RaiseEvent += (sender, e) => { };

			list = new List<string>
			{
				"1",
				"2",
				"3"
			};

			Initialize();
		}

		private void Watch()
		{
			var watcher = new FileSystemWatcher
			{
				Path = "",
				Filter = "*.txt",
				EnableRaisingEvents = true
			};
			watcher.Dispose();
		}

		private void Initialize()
		{
			(string First, string Second) tuple = GetTuple();
			string one = tuple.First;
			string two = tuple.Second;
			(string foo, string bar) otherTuple = (one, two);

			if (tuple != otherTuple)
			{
				throw new InvalidOperationException();
			}

			var anonymous = new
			{
				one,
				two
			};

			string text = null;
			string result = text ?? "text";

			string representation = anonymous?.ToString();

			Console.WriteLine($"{result} - {representation}");
		}

		public float GetField()
		{
			return myField;
		}

		public void Invoke(string message)
		{
			RaiseEvent?.Invoke(this, new MyEventArgs(message));
		}

		public IReadOnlyList<char> GetCharacters()
		{
			IEnumerable<char> query = from item in list
									  where item.Length == 1
									  select item[0];
			return query.ToList();
		}

		public void Print()
		{
			(string name, int age) = GetPersonTuple();
			Console.WriteLine($"{name} {age}");

			(int x, int y) = GetPointTuple();
			Console.WriteLine($"{x} {y}");
		}

		private static void SetField<T>(ref T field, T value)
		{
			if (!EqualityComparer<T>.Default.Equals(field, value))
			{
				field = value;
			}
		}

		private static T GetDefault<T>()
		{
			return default;
		}

		private static (string First, string Second) GetTuple()
		{
			return ("first", "second");
		}

		private static (string name, int age) GetPersonTuple()
		{
			return ("Name", 42);
		}

		private static (int x, int y) GetPointTuple()
		{
			return (1, 2);
		}
	}

	public static class Mathematics
	{
		public static bool IsEven(int integer)
		{
			return (integer / 2) == 0;
		}

		public static bool IsOdd(int integer)
		{
			return (integer / 2) != 0;
		}

		public static int Fibonacci(int value)
		{
			return fibonacci(value);

			int fibonacci(int n)
			{
				return n <= 1 ? 1 : fibonacci(n - 1) + fibonacci(n - 2);
			}
		}
	}

	public class ConverterService
	{
		public int this[Numeral i]
		{
			get => numerals[i];
			set => numerals[i] = value;
		}

		private readonly Dictionary<Numeral, int> numerals;

		public ConverterService()
		{
			numerals = new Dictionary<Numeral, int>
			{
				{ Numeral.Zero, 0 },
				{ Numeral.One, 1 }
			};
		}

		public string ConvertToString(object value)
		{
			if (value is char character)
			{
				return $"{character}({nameof(Char)})";
			}

			if (value is string text)
			{
				return $"{text}({nameof(String)})";
			}

			if (value is int integer)
			{
				return $"{integer}({nameof(Int32)})";
			}

			if (Single.TryParse(value.ToString(), out float single))
			{
				return $"{single}({nameof(Single)})";
			}

			string result;

			switch (value)
			{
				case double number:
					result = $"{number}({nameof(Double)})";
					break;
				case Numeral numeral when numerals.TryGetValue(numeral, out int number):
					result = $"{numeral}({nameof(Numeral)})[{number}]";
					break;
				case Numeral numeral:
					result = $"{numeral}({nameof(Numeral)})";
					break;
				default:
					result = "unknown value";
					break;
				case null:
					throw new ArgumentNullException((nameof(value)));
			}

			return result;
		}
	}

	public enum Numeral
	{
		Zero,
		One
	}

	public class ExceptionService
	{
		public int Calls { get; private set; }

		public T Catch<T>(Action action) where T : Exception
		{
			T exception = null;

			try
			{
				action();
			}
			catch (Exception ex) when (ex.GetType().Equals(typeof(T)))
			{
				exception = (T)ex;
			}
			finally
			{
				Calls++;
			}

			return exception;
		}
	}

	public class MyEventArgs : EventArgs
	{
		public string Message { get; }

		public MyEventArgs(string message)
		{
			Message = message ?? throw new ArgumentNullException(nameof(message));
		}

		~MyEventArgs()
		{
			Console.WriteLine($"The {ToString()} destructor is executing.");
		}
	}

	public readonly struct MyStruct : IEquatable<MyStruct>
	{
		public double Number { get; }

		public MyStruct(double number)
		{
			Number = number;
		}

		public bool Equals(MyStruct other)
		{
			return Number == other.Number;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}

			if (!(obj is MyStruct))
			{
				return false;
			}

			return Equals((MyStruct)obj);
		}

		public override int GetHashCode()
		{
			return Number.GetHashCode();
		}

		public static bool operator ==(MyStruct left, MyStruct right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(MyStruct left, MyStruct right)
		{
			return !(left.Equals(right));
		}

		public override string ToString()
		{
			return $"{nameof(Number)}: {Number}";
		}
	}

	public class MyService
	{
		public async Task DoWorkAsync(CancellationToken cancellationToken = default)
		{
			int milliseconds = 10_000;
			await Task.Delay(milliseconds, cancellationToken);
		}

		public async Task<string> GetGitHubUserInfoAsync()
		{
			const string userAgent = "Flash0ver";
			const string loginName = "Flash0ver";

			var github = new GitHubClient(new ProductHeaderValue(userAgent));
			User user = await github.User.Get(loginName);
			return $"{user.Followers} folks follow {loginName}!";
		}
	}
}

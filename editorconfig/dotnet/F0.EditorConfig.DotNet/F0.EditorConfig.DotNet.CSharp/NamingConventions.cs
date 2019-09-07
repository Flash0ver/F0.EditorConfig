using System.Threading.Tasks;

namespace F0.EditorConfig.DotNet.CSharp
{
	public class NamingConventions
	{
	}

	internal class AsynchronousMethodsMustEndInAsync
	{
		// async_methods_end_in_async
		internal async void MethodAsync()
		{
			await Task.Yield();
		}
	}
}

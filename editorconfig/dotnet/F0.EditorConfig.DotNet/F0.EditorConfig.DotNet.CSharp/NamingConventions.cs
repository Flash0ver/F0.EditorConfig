using System.Threading.Tasks;

namespace F0.EditorConfig.DotNet.CSharp
{
	public class NamingConventions
	{
	}

	internal class AsynchronousMethodsMustEndInAsync
	{
		// async_methods_end_in_async
		private async void MethodAsync()
		{
			await Task.Yield();
		}
	}
}

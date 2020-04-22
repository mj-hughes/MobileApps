using System;
using System.Threading.Tasks;

namespace Code11JokesDatabase
{
    public static class TaskExtensions
    {
        // Class constructors can't be asynchronous. Yet we want to
        //   initialize the db connection without slowing the screen ready.
        //   moreover, async without wait won't throw exceptions
        //   (and wait blocks the thrad and swallows exceptions).
        // Async void is a way to call an async method from the constructor
        // while communicating intend to fire and forget and
        // allow exception handling.
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }
            catch (Exception ex) when (onException!=null)
            {
                onException(ex);
            }
        }

    }
}

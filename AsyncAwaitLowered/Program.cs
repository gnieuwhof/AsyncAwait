namespace AsyncAwaitLowered
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    internal class Program
    {
        [CompilerGenerated]
        private sealed class MainAsyncState : IAsyncStateMachine
        {
            public int _state;

            public AsyncTaskMethodBuilder _builder;

            public string[] args;

            private int n1;

            private int o2;

            private int s3;

            private int s4;

            private TaskAwaiter<int> _awaiter;

            public void MoveNext()
            {
                int num = _state;
                try
                {
                    TaskAwaiter<int> awaiter;
                    TaskAwaiter<int> awaiter2;
                    if (num != 0)
                    {
                        if (num == 1)
                        {
                            awaiter = _awaiter;
                            _awaiter = default(TaskAwaiter<int>);
                            num = (_state = -1);
                            goto IL_00ea;
                        }
                        awaiter2 = GetNumber().GetAwaiter();
                        if (!awaiter2.IsCompleted)
                        {
                            num = (_state = 0);
                            _awaiter = awaiter2;
                            MainAsyncState stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref awaiter2, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter2 = _awaiter;
                        _awaiter = default(TaskAwaiter<int>);
                        num = (_state = -1);
                    }
                    s3 = awaiter2.GetResult();
                    n1 = s3;
                    Console.WriteLine(n1);
                    awaiter = GetNumber().GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (_state = 1);
                        _awaiter = awaiter;
                        MainAsyncState stateMachine = this;
                        _builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                    goto IL_00ea;
                IL_00ea:
                    s4 = awaiter.GetResult();
                    o2 = s4;
                    Console.WriteLine(o2);
                }
                catch (Exception exception)
                {
                    _state = -2;
                    _builder.SetException(exception);
                    return;
                }
                _state = -2;
                _builder.SetResult();
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        private sealed class GetNumberState : IAsyncStateMachine
        {
            public int _state;

            public AsyncTaskMethodBuilder<int> _builder;

            private TaskAwaiter _awaiter;

            public void MoveNext()
            {
                int num = _state;
                int result;
                try
                {
                    TaskAwaiter awaiter;
                    if (num != 0)
                    {
                        awaiter = Task.Delay(100).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = (_state = 0);
                            _awaiter = awaiter;
                            GetNumberState stateMachine = this;
                            _builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                            return;
                        }
                    }
                    else
                    {
                        awaiter = _awaiter;
                        _awaiter = default(TaskAwaiter);
                        num = (_state = -1);
                    }
                    awaiter.GetResult();
                    result = 42;
                }
                catch (Exception exception)
                {
                    _state = -2;
                    _builder.SetException(exception);
                    return;
                }
                _state = -2;
                _builder.SetResult(result);
            }

            public void SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }

        private static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();

            Console.ReadKey();
        }

        private static Task MainAsync(string[] args)
        {
            MainAsyncState stateMachine = new MainAsyncState();
            stateMachine._builder = AsyncTaskMethodBuilder.Create();
            stateMachine.args = args;
            stateMachine._state = -1;
            stateMachine._builder.Start(ref stateMachine);
            return stateMachine._builder.Task;
        }

        private static Task<int> GetNumber()
        {
            GetNumberState stateMachine = new GetNumberState();
            stateMachine._builder = AsyncTaskMethodBuilder<int>.Create();
            stateMachine._state = -1;
            stateMachine._builder.Start(ref stateMachine);
            return stateMachine._builder.Task;
        }
    }
}

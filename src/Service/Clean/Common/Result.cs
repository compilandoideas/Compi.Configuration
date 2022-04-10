using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compi.Configuration.Clean.Service.Common
{
    public class Result
    {
        public bool IsSuccess { get; }
        public string Error { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, string error)
        {
            if (isSuccess && error != string.Empty)
                throw new InvalidOperationException();
            if (!isSuccess && error == string.Empty)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }

        public static Task<Result> FailureAsync(string message)
        {
            return Task.FromResult(new Result(false, message));
        }

        public static Result<T> Failure<T>(string message)
        {
            return new Result<T>(default, false, message);
        }

        public static Result Success()
        {
            return new Result(true, string.Empty);
        }
        public static Task<Result> SuccessAsync()
        {
            return Task.FromResult(new Result(true, string.Empty));
        }

        public static Task<Result<T>> SuccessAsync<T>(T value)
        {
            return Task.FromResult(new Result<T>(value, true, string.Empty));
        }

        public static Result<T> Success<T>(T value)
        {
            return new Result<T>(value, true, string.Empty);
        }



    }

    public class Result<T> : Result
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, string error)
            : base(isSuccess, error)
        {
            _value = value;
        }
    }
}

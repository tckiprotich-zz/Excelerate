using System;

namespace NetworkAPI.Services
{
    /// <summary>
    /// Represents a service response object that contains data, success status, and message/error message.
    /// </summary>
    /// <typeparam name="T">The type of data in the response.</typeparam>
    public class ServiceResponse<T>
    {
        /// <summary>
        /// Gets or sets the data in the response.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the response is successful.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the message in the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the error message in the response.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Creates a success response object with the specified data and message.
        /// </summary>
        /// <param name="data">The data in the response.</param>
        /// <param name="message">The message in the response.</param>
        /// <returns>A new instance of the <see cref="ServiceResponse{T}"/> class with the specified data, success status, and message.</returns>
        public static ServiceResponse<T> SuccessResponse(T data, string message = "")
        {
            return new ServiceResponse<T>
            {
                Data = data,
                Success = true,
                Message = message
            };
        }

        /// <summary>
        /// Creates an error response object with the specified error message and message.
        /// </summary>
        /// <param name="errorMessage">The error message in the response.</param>
        /// <param name="message">The message in the response.</param>
        /// <returns>A new instance of the <see cref="ServiceResponse{T}"/> class with the default data, failure status, error message, and message.</returns>
        public static ServiceResponse<T> ErrorResponse(string errorMessage, string message = "")
        {
            return new ServiceResponse<T>
            {
                Data = default,
                Success = false,
                Message = message,
                ErrorMessage = errorMessage
            };
        }
    }
}
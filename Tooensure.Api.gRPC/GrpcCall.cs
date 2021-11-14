using Tooensure.DataStructure.RepositoryPattern;

namespace Tooensure.Api.Grpc
{
    public record class GrpcCall<TEntity>(TEntity Response);
    public delegate void GrpcValdationHandlar(string message, bool condition);

    public record class GrpcServer()
    {
        public Dictionary<string, bool> Validations { get; set; } = new Dictionary<string, bool>();
    };
    public class GrpcValidationGroup
    {

        public static Dictionary<string, bool> Validations { get; private set; } = new Dictionary<string, bool>();
        public bool IsValid { get; set; } = Validate();

        public GrpcValidationGroup AddValidation(string message, bool condition)
        {               
            Validations.Add(message, condition);
            return this;
        }

        public static bool Validate()
        {

            foreach (var validation in Validations)
            {
                if (validation.Value.Equals(true)) return false;
            }
            return true;
        }
        public string GetFailValidation()
        {
            //1. Initualize empty string
            var log = string.Empty;

            //2. forch each true validation append string
            foreach (var validation in Validations)
            {
                if (validation.Value.Equals(true)) log += $"[{validation.Key}], "; Validations.Remove(validation.Key);
            }
            return log;
        }
    }

    // Validate()

    //{
    //    public static ServiceResponse<TEntity> Request(TEntity response, string message)
    //    {

    //        try
    //        {
    //            /* https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9 */
    //            return new(response, true, "");

    //        }
    //        catch (Exception)
    //        {

    //            return new(Data: , false, message);
    //        }

    //    }
    //}
}
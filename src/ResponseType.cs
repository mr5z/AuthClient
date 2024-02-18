namespace AuthClient;

public class ResponseType
{
    private readonly string value;
    private ResponseType(string value) => this.value = value;
    public override string ToString() => this.value;

    public static readonly ResponseType Code = new ResponseType("code");
    public static readonly ResponseType Token = new ResponseType("token");
    public static readonly ResponseType IdToken = new ResponseType("id_token");
}
using System.Text.Json.Serialization;
using Entities.Enums;

namespace Entities.Tables;

public class SocialNetworkAccountType
{
    public SocialNetworkAccountTypeEnum Id { get; set; }
    public string Description { get; set; }
    [JsonIgnore]
    public virtual List<SocialNetworkAccount> Accounts { get; set; } = new();
}
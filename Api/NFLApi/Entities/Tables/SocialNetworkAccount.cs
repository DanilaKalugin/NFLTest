using System.Text.Json.Serialization;
using Entities.Enums;

namespace Entities.Tables;

public class SocialNetworkAccount
{
    [JsonIgnore]
    public Team Team { get; set; }
    public string TeamAbbreviation { get; set; }
    public SocialNetworkAccountType AccountType { get;set; }
    [JsonIgnore]
    public SocialNetworkAccountTypeEnum AccountTypeId { get;set; }
    public string AccountAddress { get; set; }
}
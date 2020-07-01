using Eintech.Data;
using Eintech.Models;
using System.Diagnostics.CodeAnalysis;

namespace Eintech.Repositories
{
    [ExcludeFromCodeCoverage]
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(EintechContext context) : base(context) { }
    }
}

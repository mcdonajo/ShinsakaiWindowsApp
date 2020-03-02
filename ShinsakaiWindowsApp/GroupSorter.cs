using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinsakaiWindowsApp
{
    public interface IGroupSorter
    {
        List<Group> sort(List<Group> groups);
        List<Group> sort(List<Group> groups, Group excludeGroup);
    }

    public abstract class AbstractGroupSorter : IGroupSorter
    {
        public List<Group> sort(List<Group> groups, Group excludeGroup)
        {
            List<Group> sortedGroups = sort(groups);
            if (sortedGroups.Contains(excludeGroup)) {
                sortedGroups.Remove(excludeGroup);
            }
            return sortedGroups;
        }

        public abstract List<Group> sort(List<Group> groups);
    }

    public class OrderGroupSorter : AbstractGroupSorter
    {
        public override List<Group> sort(List<Group> groups)
        {
            List<Group> result = groups.OrderBy(g => g.Order).ToList();
            result.Reverse();
            return result;
        }
    }

    public class ScoreGroupSorter : AbstractGroupSorter
    {
        public override List<Group> sort(List<Group> groups)
        {
            List<Group> result = groups.OrderBy(g => g.GroupScore != null ? g.GroupScore.getScore() : 0).ToList();
            return result;
        }
    }

    public class LastScoredSorter : AbstractGroupSorter
    {
        public override List<Group> sort(List<Group> groups)
        {
            List<Group> result = groups.OrderBy(g => g.LastScored != null ? g.LastScored : DateTime.MinValue).ToList();
            result.Reverse();
            return result;
        }
    }
}

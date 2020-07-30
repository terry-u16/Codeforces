using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound660Div2.Extensions;
using CodeforcesRound660Div2.Questions;

namespace CodeforcesRound660Div2.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        List<int>[] graph;
        int cityCount;
        int totalPopulation;
        int[] populations;
        int[] happinesses;
        long Error = -(1L << 50);

        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            var tests = inputStream.ReadInt();
            for (int t = 0; t < tests; t++)
            {
                (cityCount, totalPopulation) = inputStream.ReadValue<int, int>();
                graph = Enumerable.Repeat(0, cityCount).Select(_ => new List<int>()).ToArray();
                populations = inputStream.ReadIntArray();
                happinesses = inputStream.ReadIntArray();

                for (int i = 0; i < cityCount - 1; i++)
                {
                    var (from, to) = inputStream.ReadValue<int, int>();
                    from--;
                    to--;
                    graph[from].Add(to);
                    graph[to].Add(from);
                }

                var (population, happyPeople) = Dfs(0, -1);
                if (population == Error)
                {
                    yield return "NO";
                }
                else
                {
                    yield return "YES";
                }
            }
        }

        (long population, long happyPeople) Dfs(int current, int parent)
        {
            if (graph[current].Count == 1 && graph[current][0] == parent)
            {
                if (OK(populations[current], happinesses[current]))
                {
                    var happyPeople = (populations[current] + happinesses[current]) / 2;
                    return (populations[current], happyPeople);
                }
                else
                {
                    return (Error, Error);
                }
            }
            else
            {
                long passed = populations[current];
                long childrenHappyPeople = 0;
                foreach (var child in graph[current])
                {
                    if (child == parent)
                    {
                        continue;
                    }

                    var (childPopulation, childHappyPeople) = Dfs(child, current);
                    if (childPopulation == Error)
                    {
                        return (Error, Error);
                    }
                    else
                    {
                        passed += childPopulation;
                        childrenHappyPeople += childHappyPeople;
                    }
                }

                if (OK(passed, happinesses[current]))
                {
                    var happyPeople = (passed + happinesses[current]) / 2;

                    if (happyPeople >= childrenHappyPeople)
                    {
                        return (passed, happyPeople);
                    }
                    else
                    {
                        return (Error, Error);
                    }
                }
                else
                {
                    return (Error, Error);
                }
            }
        }

        bool OK(long population, long happiness) => -population <= happiness && happiness <= population && (population + happiness) % 2 == 0;
    }
}

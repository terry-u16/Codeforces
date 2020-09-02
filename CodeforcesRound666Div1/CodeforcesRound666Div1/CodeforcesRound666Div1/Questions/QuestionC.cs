using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CodeforcesRound666Div1.Extensions;
using CodeforcesRound666Div1.Questions;

namespace CodeforcesRound666Div1.Questions
{
    public class QuestionC : AtCoderQuestionBase
    {
        public override IEnumerable<object> Solve(TextReader inputStream)
        {
            const int Initial = 0;
            const int KilledCommon = 1;
            const int DamagedBoss = 2;
            const int DamagedBossNext = 3;   // 今のボスと次のボスにダメージ
            const long Inf = 1L << 60;

            var (levels, reloadPistol, reloadLaser, reloadAwp, teleportation) = inputStream.ReadValue<int, long, long, long, long>();
            var minReload = Math.Min(reloadPistol, Math.Min(reloadLaser, reloadAwp));
            var enemies = inputStream.ReadIntArray();

            var minTime = new long[levels + 1, DamagedBossNext + 1];
            for (int i = 0; i <= levels; i++)
            {
                for (int j = 0; j <= DamagedBossNext; j++)
                {
                    minTime[i, j] = Inf;
                }
            }

            minTime[0, Initial] = 0;

            for (int level = 0; level < levels; level++)
            {
                // [初期状態]
                // pistol
                // とりあえず雑魚を倒す
                UpdateWhenSmall(ref minTime[level, KilledCommon], minTime[level, Initial] + reloadPistol * enemies[level]);

                // laser
                // すぐ戻る
                UpdateWhenSmall(ref minTime[level, DamagedBoss], minTime[level, Initial] + reloadLaser + 2 * teleportation);
                // 次のボスにも攻撃して戻ってくる
                if (level + 1 < levels)
                {
                    // ピストル版
                    UpdateWhenSmall(ref minTime[level, DamagedBossNext], minTime[level, Initial] + reloadLaser + (1 + enemies[level + 1]) * reloadPistol + 2 * teleportation);
                    // レーザー版
                    UpdateWhenSmall(ref minTime[level, DamagedBossNext], minTime[level, Initial] + 2 * reloadLaser + 2 * teleportation);
                }

                // AWP
                // 全滅させる（わざわざボスだけピストル・レーザーを使う意味はない）
                UpdateWhenSmall(ref minTime[level + 1, Initial], minTime[level, Initial] + (enemies[level] + 1) * reloadAwp + teleportation);

                // [雑魚全滅状態]
                // pistol
                // ボスを攻撃して反復横跳び
                UpdateWhenSmall(ref minTime[level, DamagedBoss], minTime[level, KilledCommon] + reloadPistol + 2 * teleportation);
                // 次のボスにも攻撃して戻ってくる
                if (level + 1 < levels)
                {
                    // ピストル版
                    UpdateWhenSmall(ref minTime[level, DamagedBossNext], minTime[level, KilledCommon] + (2 + enemies[level + 1]) * reloadPistol + 2 * teleportation);
                    // レーザー版
                    UpdateWhenSmall(ref minTime[level, DamagedBossNext], minTime[level, KilledCommon] + reloadPistol + reloadLaser + 2 * teleportation);
                }

                // laser（これいる？）
                // ボスを攻撃して反復横跳び
                UpdateWhenSmall(ref minTime[level, DamagedBoss], minTime[level, KilledCommon] + reloadLaser + 2 * teleportation);
                // 次のボスにも攻撃して戻ってくる
                if (level + 1 < levels)
                {
                    // ピストル版
                    UpdateWhenSmall(ref minTime[level, DamagedBossNext], minTime[level, KilledCommon] + reloadLaser + (1 + enemies[level + 1]) * reloadPistol + 2 * teleportation);
                    // レーザー版
                    UpdateWhenSmall(ref minTime[level, DamagedBossNext], minTime[level, KilledCommon] + 2 * reloadLaser + 2 * teleportation);
                }

                // AWP
                UpdateWhenSmall(ref minTime[level + 1, Initial], minTime[level, KilledCommon] + reloadAwp + teleportation);

                // [ボスにダメージを与えてる状態]
                // pistol
                UpdateWhenSmall(ref minTime[level + 1, Initial], minTime[level, DamagedBoss] + reloadPistol + teleportation);

                // laser
                UpdateWhenSmall(ref minTime[level + 1, Initial], minTime[level, DamagedBoss] + reloadLaser + teleportation);

                // AWP
                UpdateWhenSmall(ref minTime[level + 1, Initial], minTime[level, DamagedBoss] + reloadAwp + teleportation);

                // [次のボスにもダメージを与えてる状態]
                // pistol
                UpdateWhenSmall(ref minTime[level + 1, DamagedBoss], minTime[level, DamagedBossNext] + reloadPistol + teleportation);

                // laser
                UpdateWhenSmall(ref minTime[level + 1, DamagedBoss], minTime[level, DamagedBossNext] + reloadLaser + teleportation);

                // AWP
                UpdateWhenSmall(ref minTime[level + 1, DamagedBoss], minTime[level, DamagedBossNext] + reloadAwp + teleportation);

                // level n-1 で終わらせる
                if (level == levels - 2)
                {
                    UpdateWhenSmall(ref minTime[level + 2, Initial],
                        minTime[level, Initial] + (enemies[level] + 1) * Math.Min(reloadPistol, reloadAwp) + enemies[level + 1] * Math.Min(reloadPistol, reloadAwp) + reloadAwp + 2 * teleportation + minReload);
                    UpdateWhenSmall(ref minTime[level + 2, Initial],
                        minTime[level, Initial] + reloadLaser + enemies[level + 1] * Math.Min(reloadPistol, reloadAwp) + reloadAwp + 2 * teleportation + minReload);
                }
            }

            yield return minTime[levels, Initial];
        }

        public static void UpdateWhenSmall<T>(ref T value, T other) where T : IComparable<T>
        {
            if (other.CompareTo(value) < 0)
            {
                value = other;
            }
        }
    }
}

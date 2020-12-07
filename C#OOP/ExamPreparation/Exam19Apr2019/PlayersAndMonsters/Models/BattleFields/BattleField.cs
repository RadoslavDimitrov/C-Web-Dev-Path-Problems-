using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if(attackPlayer.IsDead == true || enemyPlayer.IsDead == true)
            {
                throw new ArgumentException("Player is dead!");
            }

            if(attackPlayer.GetType().Name == "Beginner") 
            {
                attackPlayer.Health += 40;
                foreach (var item in attackPlayer.CardRepository.Cards)
                {
                    item.DamagePoints += 30;
                }              
            }

            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;
                foreach (var item in enemyPlayer.CardRepository.Cards)
                {
                    item.DamagePoints += 30;
                }
            }

            int attackerAttack = 0;
            int enemyAttack = 0;

            foreach (var item in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += item.HealthPoints;
                attackerAttack += item.DamagePoints;
            }

            foreach (var item in enemyPlayer.CardRepository.Cards)
            {
                enemyPlayer.Health += item.HealthPoints;
                enemyAttack += item.DamagePoints;
            }

            while (attackPlayer.IsDead != true && enemyPlayer.IsDead != true)
            {
                enemyPlayer.TakeDamage(attackerAttack);

                if (enemyPlayer.IsDead)
                {
                    break;
                }

                attackPlayer.TakeDamage(enemyAttack);
            }
        }
    }
}

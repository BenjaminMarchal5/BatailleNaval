using BattleShip.Model;
using BattleShip.Model.Enum;
using BattleShip.Model.Model;
using BattleShip.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShip.Model.Strategy
{
    public class IStrategyIANormal : IStrategyIA
    {
        
        public List<Position> ImpossiblePosition(List<Position> ShipAlreadyDown)
        {
            List<Position> positions = new List<Position>();
            foreach (var s in ShipAlreadyDown)
            {
                positions.AddRange(s.PositionAround());
            }
            positions = positions.Distinct().ToList();
            return positions;
        }

        public override Position NextShootPosition(int GridSize,List<Shoot> AllMyShoot)
        {
            int MaxShoot = GridSize * GridSize;
            if (AllMyShoot.Count >= MaxShoot)
            {
                throw new Exception("");
            }
            
            var AllShootHit = AllMyShoot.FindAll(i => i.HasHit && i.Ship.ShipState() == EShipState.HIT).ToList();
            var AllShootShipDown = AllMyShoot.FindAll(i => i.HasHit && i.Ship.ShipState() == EShipState.SINK).ToList();
            var impossiblePosition = ImpossiblePosition(AllShootShipDown.Select(i => i.Hit).ToList());
            if (AllShootHit.Count==1)
            {
                List<Position> AroundPosition = AllShootHit[0].Hit.PositionAround();
                int number = random.Next(0, AroundPosition.Count);
                while (AllMyShoot.Select(i => i.Hit).Any(i => i.Equals(AroundPosition[number])) || impossiblePosition.Any(i => i.Equals(AroundPosition[number])))
                {
                    number = random.Next(0, AroundPosition.Count);
                }
                return AroundPosition[number];
            }
            else if (AllShootHit.Count>1)
            {
                List<Position> positions = AllShootHit.Select(i => i.Hit).ToList();
                Position start = UtilsFunction.GetInstance().GetMin(positions);
                Position end = UtilsFunction.GetInstance().GetMax(positions); 
                return UtilsFunction.GetInstance().PositionNextTo(start,end,GridSize);
            }
            else
            {
                var allImpossiblePos = new List<Position>(impossiblePosition);
                allImpossiblePos.AddRange(AllMyShoot.Select(i => i.Hit).ToList());
                allImpossiblePos = allImpossiblePos.Distinct().ToList();
                return GenerateRandomPosition(GridSize, allImpossiblePos);
            }

        }
    }
}

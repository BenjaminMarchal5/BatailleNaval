using System;
using System.Collections.Generic;
using BattleShip.Model.Factory;
using BattleShip.Model.Model;
using BattleShip.Model.Utils;

namespace BattleShip.Services.Services
{
    public class ShipRequiredService
    {
        private ShipService _shipService;
        public ShipRequiredService(ShipService shipService)
        {
            _shipService = shipService;
        }

        public List<Ship> GetPossiblePlacement(RequiredShip rp, int size)
        {
            if (rp.SizeShip == 0)
            {
                throw new Exception("Un bateau doit avoir une taille"); 
            }
            List<Ship> allShipPosition = new List<Ship>();
            for (int x = 0; x <= size; x++)
            {
                for (int y = 0 ; y <= size; y++)
                {
                    // Horizontal ship 
                    Ship h = ShipFactory.Ship(x,y,x,y + rp.SizeShip-1);
                    if (_shipService.IsInGrid(h, size))
                    {
                        //Console.WriteLine(" Ship Horizontal. Start : "+h.Start.ToString()+"End : "+h.End.ToString()+" Est dans la grille");
                        allShipPosition.Add(h);
                    }
                    // Vertical ship 
                    Ship v = ShipFactory.Ship(x,y,x+ rp.SizeShip-1,y);
                    if (_shipService.IsInGrid(v, size))
                    {
                        allShipPosition.Add(v);
                        //Console.WriteLine(" Ship Vertical. Start : "+v.Start.ToString()+"End : "+v.End.ToString()+" Est dans la grille");
                    }
                    //Diagonal ship
                    Ship d = ShipFactory.Ship(x,y,x+ rp.SizeShip-1,y+ rp.SizeShip-1);
                    if (_shipService.IsInGrid(d, size))
                    {
                        allShipPosition.Add(d);
                        //Console.WriteLine(" Ship Diagonal. Start : "+d.Start.ToString()+"End : "+d.End.ToString());
                    }
                }
            }
            
            return allShipPosition; 
        }
    }
}
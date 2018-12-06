using SpaceInvaders.Components;
using SpaceInvaders.Entities;
using SpaceInvaders.Entities.Ship;
using SpaceInvaders.Entities.Ship.Cockpits;
using SpaceInvaders.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Scenes
{
    class Scene_02_Game : Scene
    {
        public Scene_02_Game()
        {
            InstantiateMenuManagement();
            SpawnEnnemiWave();
            SpawnBunkers();
            InstantiatePlayer();
        }

        public void InstantiatePlayer()
        {
            ShipPart.COLOR color = ShipPart.COLOR.YELLOW;
            Player player = new Player(new Ship(color, 0, 0, 0, 0));
            Engine.instance.AddEntity(player);
        }

        public void InstantiateMenuManagement()
        {
            Engine.instance.AddEntity(new MenuShortcutsManager());
        }
        public void SpawnBunkers()
        {
            Engine.instance.AddEntity(new Bunker(new Vector2(RenderForm.instance.Width * 1 / 10, RenderForm.instance.Height * 7 / 10)));
            Engine.instance.AddEntity(new Bunker(new Vector2(RenderForm.instance.Width * 4 / 10, RenderForm.instance.Height * 7 / 10)));
            Engine.instance.AddEntity(new Bunker(new Vector2(RenderForm.instance.Width * 7 / 10, RenderForm.instance.Height * 7 / 10)));
        }
        public void SpawnEnnemiWave(int ennemiesByLine = 3, int ennemiesByColumn = 2)
        {
            List<EnnemiLine> ennemiBlocList = new List<EnnemiLine>();
            for (int y = 0; y < ennemiesByColumn; y++)
            {
                List<Ennemi> ennemiLineList = new List<Ennemi>();
                for (int x = 0; x < ennemiesByLine; x++)
                {
                    Ennemi ennemi = new Ennemi();
                    ennemiLineList.Add(ennemi);
                    Engine.instance.AddEntity(ennemi);
                    TransformComponent positionComponent = ennemi.Components[typeof(TransformComponent)] as TransformComponent;
                    RenderComponent renderComponent = ennemi.Components[typeof(RenderComponent)] as RenderComponent;
                    float height = (RenderForm.instance.Height * .2f) + y * (renderComponent.Images.Height + 15);
                    float width = x * (renderComponent.Images.Width + 40);
                    positionComponent.Position = new Vector2(width, height);
                }
                EnnemiLine ennemiLine = new EnnemiLine(ennemiLineList);
                Engine.instance.AddEntity(ennemiLine);
                ennemiBlocList.Add(ennemiLine);
            }
            EnnemiBloc ennemiBloc = new EnnemiBloc(ennemiBlocList);
            Engine.instance.AddEntity(ennemiBloc);
        }

    }
}

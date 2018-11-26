using SpaceInvaders.Components;
using SpaceInvaders.Entities;
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
            //SpawnBunkers();
            Engine.instance.AddEntity(new Player());
        }

        public void InstantiateMenuManagement()
        {
            Engine.instance.AddEntity(new MenuShortcutsManager());
        }
        public void SpawnBunkers()
        {
            Engine.instance.AddEntity(new Bunker(new Vecteur2D(RenderForm.instance.Width * 1 / 10, RenderForm.instance.Height * 7 / 10)));
            Engine.instance.AddEntity(new Bunker(new Vecteur2D(RenderForm.instance.Width * 4 / 10, RenderForm.instance.Height * 7 / 10)));
            Engine.instance.AddEntity(new Bunker(new Vecteur2D(RenderForm.instance.Width * 7 / 10, RenderForm.instance.Height * 7 / 10)));
        }
        public void SpawnEnnemiWave(int ennemiesByLine = 7, int ennemiesByColumn = 4)
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
                    TransformComponent positionComponent = (TransformComponent)ennemi.GetComponent(typeof(TransformComponent));
                    RenderComponent renderComponent = (RenderComponent)ennemi.GetComponent(typeof(RenderComponent));
                    float height = (RenderForm.instance.Height * .2f) + y * (renderComponent.Image.Height + 15);
                    float width = x * (renderComponent.Image.Width + 40);
                    positionComponent.Position = new Vecteur2D(width, height);
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

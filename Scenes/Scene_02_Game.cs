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
            Engine.instance.AddEntity(new Player());

            SpawnEnnemiWave();
        }

        public void SpawnEnnemiWave(int ennemiesByLine = 7, int ennemiesByColumn = 5)
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
                    float height = (RenderForm.instance.Height * .1f) + y * (renderComponent.Image.Height + 15);
                    float width = x * (renderComponent.Image.Width + 20);
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

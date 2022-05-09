using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Xaml;
using System.Xml.Linq;
using HikerEditor.Models.Interfaces;

namespace HikerEditor.Models.GameProject
{
    /// <summary>
    /// Исходные файлы игры, объединенные логической сущностью - проектом
    /// </summary>
    public class Project
    {
        private String _name;

        public Project()
        {
            Entities = new ObservableCollection<IEntity>();
            Systems = new ObservableCollection<ISystem>();
            Components = new ObservableCollection<IComponent>();
            Resources = new ObservableCollection<IResource>();
            Name = "<Untitled Project>";

            Resources.Add(new BaseResource() { Name = "DefaultResource", FilePath = "/Resources/Images/sprite.png" } );
        }

        /// <summary>
        /// Название проекта
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnProjectNameChanged?.Invoke(_name);
            }
        }

        /// <summary>
        /// Все игровые сущности проекта
        /// </summary>
        public IList<IEntity> Entities { get; private set; }

        /// <summary>
        /// Все доступные компоненты проекта
        /// </summary>
        public IList<IComponent> Components { get; private set; }

        /// <summary>
        /// Все системы проекта
        /// </summary>
        public IList<ISystem> Systems { get; private set; }

        /// <summary>
        /// Ресурсы, которые может использовать проект
        /// </summary>
        public IList<IResource> Resources { get; private set; }

        public void Save(string directoryToSave)
        {
            XDocument xDoc = new XDocument();

            XElement project = new XElement("Project");
            XAttribute projectName = new XAttribute("Name", Name);
            project.Add(projectName);

            XElement resources = new XElement("Resources");

            foreach (var resource in Resources)
            {
                XElement xRes = new XElement("Resource");
                XAttribute filepath = new XAttribute("FilePath", resource.FilePath);
                XAttribute name = new XAttribute("Name", resource.Name);

                xRes.Add(name);
                xRes.Add(filepath);
                resources.Add(xRes);
            }

            project.Add(resources);

            XElement entities = new XElement("Entities");

            foreach (var entity in Entities)
            {
                XElement xEntity = new XElement("Entity");
                XAttribute id = new XAttribute("Id", entity.Id);
                XAttribute name = new XAttribute("Name", entity.Name);

                xEntity.Add(id);
                xEntity.Add(name);

                XElement xVisualComponent = new XElement("Component");
                XAttribute componentName = new XAttribute("Name", entity.VisualComponent.Name);
                XAttribute xPosition = new XAttribute("XPos", entity.VisualComponent.WorldPosition.X);
                XAttribute yPosition = new XAttribute("YPos", entity.VisualComponent.WorldPosition.Y);
                XAttribute image = new XAttribute("Image", entity.VisualComponent.Image.Name);

                xVisualComponent.Add(componentName);
                xVisualComponent.Add(xPosition);
                xVisualComponent.Add(yPosition);
                xVisualComponent.Add(image);

                xEntity.Add(xVisualComponent);

                entities.Add(xEntity);
            }

            project.Add(entities);

            xDoc.Add(project);

            if (!Directory.Exists(directoryToSave))
                Directory.CreateDirectory(directoryToSave);

            xDoc.Save(directoryToSave + @"/project.xml");
        }

        public void Load(string directotyToLoad)
        {
            ClearProject();

            XDocument xDoc = XDocument.Load(directotyToLoad + @"/project.xml");

            XElement project = xDoc.Element("Project");

            string projectName = project.Attribute("Name").Value;
            Name = projectName;

            XElement xResources = project.Element("Resources");
            foreach(var xRes in xResources.Elements("Resource"))
            {
                string name = xRes.Attribute("Name")?.Value;
                string filePath = xRes.Attribute("FilePath")?.Value;

                Resources.Add(new BaseResource() { Name = name, FilePath = filePath});
            }

            XElement xEntities = project.Element("Entities");
            foreach (var xEntity in xEntities.Elements("Entity"))
            {
                string name = xEntity.Attribute("Name")?.Value;
                string id = xEntity.Attribute("Id")?.Value;

                IEntity entity = new BaseEntity(Guid.Parse(id)) { Name = name };
                
                XElement xVisualComponent = xEntity.Element("Component");
                string componentName = xVisualComponent.Attribute("Name").Value;
                float xPos = Single.Parse(xVisualComponent.Attribute("XPos").Value, NumberStyles.Any, CultureInfo.InvariantCulture);
                float yPos = Single.Parse(xVisualComponent.Attribute("YPos").Value, NumberStyles.Any, CultureInfo.InvariantCulture);
                string imageName = xVisualComponent.Attribute("Image")?.Value;

                entity.VisualComponent.WorldPosition = new Vector2(xPos, yPos);
                entity.VisualComponent.Image = (BaseResource)Resources.FirstOrDefault(r => r.Name == imageName);

                Entities.Add(entity);
            }
        }

        public void ClearProject()
        {
            Entities.Clear();
            Systems.Clear();
            Components.Clear();
            Resources.Clear();
            Name = "<Untitled Project>";
        }

        public event Action<String> OnProjectNameChanged;
    }
}

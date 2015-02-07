﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace SPLConqueror_Core
{
    public class BinaryOption : ConfigurationOption
    {
        /// <summary>
        /// A binary feature can either be selected or selected in a specific configuration of a programm.
        /// </summary>
        public enum BinaryValue { Selected, Deselected };

        /// <summary>
        /// The default value of a binary option.
        /// </summary>
        public BinaryValue DefaultValue { get; set; }


        public bool Optional { get; set; }

        /// <summary>
        /// Constructor of a binary option. Optional is set to false and the default value is set to selected.
        /// </summary>
        /// <param name="vm">Corresponding variability model</param>
        /// <param name="name">Name of that option</param>
        public BinaryOption(VariabilityModel vm, String name)
            : base(vm, name)
        {
            this.Optional = false;
            this.DefaultValue = BinaryValue.Selected;
        }

        /// <summary>
        /// Stores the binary options as an XML node (calling base implementation)
        /// </summary>
        /// <param name="doc">The XML document to which the node will be added</param>
        /// <returns>The XML node containing the options information</returns>
        internal XmlNode saveXML(System.Xml.XmlDocument doc)
        {
            XmlNode node = base.saveXML(doc);

            //Default value
            XmlNode defaultNode = doc.CreateNode(XmlNodeType.Element, "defaultValue", "");
            if (this.DefaultValue == BinaryValue.Selected)
                defaultNode.InnerText = "Selected";
            else
                defaultNode.InnerText = "Deselected";
            node.AppendChild(defaultNode);

            //Optional
            XmlNode optionalNode = doc.CreateNode(XmlNodeType.Element, "optional", "");
            if (this.Optional)
                optionalNode.InnerText = "True";
            else
                optionalNode.InnerText = "False";
            node.AppendChild(optionalNode);

            return node;
        }
    }
}

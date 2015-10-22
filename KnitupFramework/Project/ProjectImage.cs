using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnitupFramework.Project
{

    public class ProjectImage
    {

        #region public properties

        public String ID { get; private set; } = "images\\" + Guid.NewGuid().ToString();

        public String Name { get; set; }

        public Image Image { get; set; }

        #endregion

        #region constructor / destructor

        public ProjectImage(String iID,
            String iName)
        {
            ID = iID;
            Name = iName;
        }

        public ProjectImage(String iName,
            Image iImage)
        {
            Name = iName;
            Image = iImage;
        }

        #endregion

        #region public methods

        public JObject ToJSON()
        {
            JObject pJOtJSON = new JObject();
            pJOtJSON.Add("ID", new JValue(ID));
            pJOtJSON.Add("Name", new JValue(Name));
            return (pJOtJSON);
        }

        public static ProjectImage FromJSON(JObject iJSON)
        {
            ProjectImage pPIeImage = new ProjectImage(iJSON["ID"].Value<String>(),
                iJSON["Name"].Value<String>());
            return (pPIeImage);
        }

        #endregion

        #region base class overrides

        public override string ToString()
        {
            return (Name);
        }

        #endregion

    }

}

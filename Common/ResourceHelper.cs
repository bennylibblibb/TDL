using System.Configuration;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Web.UI;

namespace CENTASMS.Common
{
	public class ResourceHelper
	{
		private ResourceManager _rm = null;
		private Page _page = null;

		public ResourceHelper(Page page)
		{
			_page = page;
			PrepareResource();
		}

		/**/

		/// <summary>
		/// ��õ�ǰ�Ļ�����Session["HWcultureName"]ȡ
		/// </summary>
		protected CultureInfo GetCurrentCulture
		{
			get
			{
				if (_page.Session["HWCultureName"] != null)
					return CultureInfo.CreateSpecificCulture(_page.Session["HWCultureName"].ToString());
				else //���Sessionδ���ã���ֱ�Ӵ�web.config�ж�ȡĬ������
					return CultureInfo.CreateSpecificCulture(ConfigurationSettings.AppSettings["CultureName"]);
			}
		}

		/**/

		/// <summary>
		/// ��ʼ����Դ����
		/// </summary>
		public void PrepareResource()
		{
			_rm =
				ResourceManager.CreateFileBasedResourceManager("strings",
				                                               _page.Server.MapPath("resources") + Path.DirectorySeparatorChar, null);
		}

		/**/

		/// <summary>
		/// �����Դָ��
		/// </summary>
		protected ResourceManager resource
		{
			get
			{
				if (_rm == null)
					PrepareResource();
				return _rm;
			}
		}

		/**/

		/// <summary>
		/// �����Դ�ַ���
		/// </summary>
		/// <param name="ResourceID">��ԴID</param>
		/// <returns></returns>
		public string GetString(string ResourceID)
		{
			return resource.GetString(ResourceID, GetCurrentCulture);
		}
	}
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TmdbApi;

namespace TmdbBrowser
{
	public partial class Show : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			var s = Request["show"];
			if (!string.IsNullOrEmpty(s))
			{
				int showId = -1;
				if(int.TryParse(s,out showId))
				{
					show = new TmdbShow(showId);
				}
			}
			if (null == show)
				show = new TmdbShow(2919);
		}
		public int tvid = -1;
		public TmdbShow show = null;
		public string HtmlEncodeElem(string str)
		{
			if (null == str) str = "";
			return str.Replace("\r", "").Replace("\n", "<br />\n").Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;");
		}
		public string Denull(string str, string @default = null)
		{
			if (null == str) return @default == null ? "" : @default;
			return str;
		}
		protected TimeSpan ApproxRunTime
		{
			get {
				return new TimeSpan(0, (int)(show.EpisodeRunTime.TotalMinutes * show.TotalEpisodes), 0);
			}
		}
	}
}
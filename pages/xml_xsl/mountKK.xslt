<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
 
  <xsl:template match="/mountKK">
  
   	<div style="border-top: 2px solid whitesmoke;border-bottom: 2px solid whitesmoke;margin-top: 10px;" class="slogan">
			<h2><xsl:value-of select="mountKK_title" /></h2>
            <br/>
            <a runat="server" href="~/pages/rareSpecies.aspx">
			<img runat="server" id="img" style="margin-left: 0;"  alt="mountKK" title="Mount Kinabalu"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="mounKK_1stPic" /> 
					</xsl:attribute> 
				</img> 
			</a>
			<br/>
			<p><font size="+1" color="darkblue"> <xsl:value-of select="mounKK_1st_para" /> </font></p>
			
			<p><font size="+1" color="darkblue"><xsl:value-of select="mounKK_2nd_para" /></font>
			</p>
			 <br/><a runat="server" href="~/pages/rareSpecies.aspx">
			 <img runat="server" id="img2" style="margin-left: 0;"  alt="mountKK" title="Mount Kinabalu"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="mounKK_2ndPic" /> 
					</xsl:attribute> 
				</img> 
				</a>
				<br/>
			<h2><xsl:value-of select="mounKK_1st_sub_title" /> </h2>
			<p><font size="+1" color="darkblue"> <xsl:value-of select="mounKK_3rd_para" /> </font></p>
			 <p><font size="+1" color="darkblue"><xsl:value-of select="mounKK_4th_para" /> </font></p>
			
		</div>
		 
	   
	   
  </xsl:template>
</xsl:stylesheet>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
  <xsl:param name="selected_traveller"/>
  <xsl:template match="/">
		<xsl:for-each select="//User[./User_name=$selected_traveller]">
			<a  style=" cursor: pointer;text-decoration: none;color: brown;font-weight: 500;" runat="server" target="_blank">
				<xsl:attribute name="href"><!-- create the href attribute -->
						manageUser.aspx?username=<xsl:value-of select="User_name"/>
				</xsl:attribute>
				<div id="content_wrapper" style="    width: 100%; border:2px outset orange;">
					<div style="width:100%;  display: inline-flex;">
						<div style="width: 30%;float:left;text-align: center;padding:2%;border-right:2px outset orange;">
							<img runat="server" class="img" alt="Profile" title="Profile" style="border-radius:50%;    margin: 2%;width: 90%;height:70%;border: 2px outset white;"> 
								<xsl:attribute name="src"> 
									<xsl:value-of select="User_profile_img" /> 
								</xsl:attribute> 
							</img> 		
							<div style="width:100%;"><xsl:value-of select="User_name" /> </div>
						</div> 
						<div style="width: 35%;float:left;left:50%;text-align: left;overflow: scroll;padding:10px;">
							<div style="width:100%; "><xsl:value-of select="User_email" /> </div>
						</div> 
					  
						<div style="width: 35%;float:right;right:0;text-align: left;overflow: scroll;padding:10px;border-left:2px outset orange;">
							<div style="width:100%;"><xsl:value-of select="User_pwd" /></div>
						</div> 
					</div>
				</div>
			</a>
    </xsl:for-each>
   
  </xsl:template>
</xsl:stylesheet>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
  <xsl:template match="/">     
	   <xsl:for-each select="//borneo_hot_post">
	      <div class="panel panel-success" style="margin-bottom:10px;">
			   <a style=" cursor: pointer;text-decoration: none;color: brown;font-weight: 500;" runat="server" >
				    <xsl:attribute name="href"><!-- create the href attribute -->
						  <xsl:value-of select="borneo_hot_post_url"/>
					  </xsl:attribute>
			      <div style="background-color: chocolate;" class="  panel-heading  row-centered bg-info">
              <h5 style="color:wheat;font-family:cursive;font-size:20px;"><xsl:value-of select="borneo_hot_post_title" /> </h5>
            </div>
          </a>
				<div style="background-color:silver; " class="panel-body">
           <div style="    border-radius: 10px;" class="row-centered bg-danger">
              <a   style=" cursor: pointer;text-decoration: none;color: brown;font-weight: 500;" runat="server" >
				        <xsl:attribute name="href"><!-- create the href attribute -->
						      <xsl:value-of select="borneo_hot_post_url"/>
					      </xsl:attribute>
				        <img runat="server" class="img"  alt="hotel" title="Borneo Hot" style="border-radius: 20px !important;width:100%;height:20%;padding:10px;"> 
					      <xsl:attribute name="src"> 
						      <xsl:value-of select="borneo_hot_post_img" /> 
					      </xsl:attribute> 
				        </img> 
				      </a>
					 </div>
                  
				    <a  style=" cursor: pointer;text-decoration: none;color: brown;font-weight: 800;font-family:cursive;font-size:16px;" runat="server" >
				 <xsl:attribute name="href"><!-- create the href attribute -->
						<xsl:value-of select="borneo_hot_post_url"/>
					</xsl:attribute> <div style="margin-top:10px;">
					<xsl:value-of select="borneo_hot_post_title" />
                     </div> </a>
                  </div>
            </div>
	   
	   </xsl:for-each>
	   
	   
  </xsl:template>
</xsl:stylesheet>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
 
  <xsl:template match="/borneoRainforest">
  
      
	<div id="content" class="row-centered" style="border-top: 2px solid whitesmoke;border-bottom: 2px solid whitesmoke;margin-top: 10px;text-align:center;" >

		<h3> <xsl:value-of select="borneoRainforest_title1" /> </h3>
		<h4><xsl:value-of select="borneoRainforest_p1" /> </h4><br/>
		
        <div id="img_danum_left" style="padding-left:10px;padding-right:10px;width:100%;height:25%">
		<a runat="server"  style=" padding-right:10px;margin-top:20px;margin-bottom:20px;" href="~/pages/Home.aspx">
		
		<img runat="server" class="img" alt="danum valley" title="danum valley" style="width:100%;height:90%;"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="borneoRainforest_img1" /> 
					</xsl:attribute> 
		</img> 
				
		</a></div>
		 
		<p><xsl:value-of select="borneoRainforest_p2" /> 

		</p>

		<div id="img_danum_right" style="padding-left:10px;text-align:center;padding-right:10px;width:100%;height:25%;">
		<a runat="server" style=" padding-right:10px;margin-top:20px;margin-bottom:20px;"  href="~/pages/Home.aspx">
		<img runat="server" class="img"  alt="danum valley" title="danum valley" style="width:100%;height:90%;"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="borneoRainforest_img2" /> 
					</xsl:attribute> 
		</img> 
		 
		</a></div>
            
		<p><xsl:value-of select="borneoRainforest_p3" /> </p>
		


		<h3 style="color:darkblue;"><xsl:value-of select="borneoRainforest_title2" /></h3>
		<h4 style="color:darkgray;"><xsl:value-of select="borneoRainforest_title2_sub1" /></h4>

		<p> <xsl:value-of select="borneoRainforest_p4" />
		
            <a runat="server" href="~/pages/rareSpecies">orangutan</a> 
			 <xsl:value-of select="borneoRainforest_p5" />
			 </p>

		<div  style="padding-left:10px;text-align:center;padding-right: 10px;width: 100%;height:25%;">
        <a runat="server" style=" padding-right:10px;margin-top:20px;margin-bottom:20px;" href="~/pages/rareSpecies">
			<img runat="server" class="img" alt="danum valley" title="danum valley" style="text-align:center;width:100%;height:20%;"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="borneoRainforest_img3" /> 
					</xsl:attribute> 
		</img> 
	
		</a></div>

		<br/>
        <p><xsl:value-of select="borneoRainforest_p6" /> 
		
		
        </p>
		
	
		
		<br/><hr/><br/>

		 <h3><xsl:value-of select="borneoRainforest_title3" /> </h3> 
		<h4><xsl:value-of select="borneoRainforest_title3_sub1" />  </h4>
		<p style="color: midnightblue;">
		<xsl:value-of select="borneoRainforest_p7" /> 
		
		</p>
	<div  style="padding-left:10px;text-align:center;padding-right: 10px;width: 100%;height:25%;">
      <a runat="server" style=" padding-right:10px;margin-top:20px;margin-bottom:20px;" href="~/pages/Home.aspx">
		
		<img runat="server" class="img" alt="danum valley" title="danum valley" style="text-align:center;width:100%;height:20%;"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="borneoRainforest_img4" /> 
					</xsl:attribute> 
		</img> 

		
		</a> </div>
		<br/><p>
		<xsl:value-of select="borneoRainforest_p8" /> 
		
		</p>
  </div>
	   
	   
  </xsl:template>
</xsl:stylesheet>
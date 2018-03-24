<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
 
  <xsl:template match="/waterRafting">
  
        
<div id="content" style="border-top: 2px solid whitesmoke;border-bottom: 2px solid whitesmoke;margin-top: 10px;"  >
     
<h3>	<xsl:value-of select="waterRafting_title1" /> </h3>
<p>
<xsl:value-of select="waterRafting_p1" /> 

    <a href="index.html"><strong>  Borneo</strong></a>
	<xsl:value-of select="waterRafting_p2" /> 
  
</p>

<br/><hr/> 

<a runat="server" href="~/pages/waterSport.aspx">
<img runat="server" class="img" alt="white water" title="white water" style="border-radius:10px;width:70%;margin-top:20px;margin-bottom:10px;"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterRafting_img1" /> 
					</xsl:attribute> 
				</img> 
				
		</a><br/>

<h3><b><xsl:value-of select="waterRafting_title2" /></b></h3><br/>
<p>
	<xsl:value-of select="waterRafting_p3" /> <br/><br/>
<xsl:value-of select="waterRafting_p4" /> 

</p> <br/>

<a runat="server" href="~/pages/waterSport.aspx">
<img runat="server" class="img" alt="white water" title="white water" style="border-radius:10px;width:70%;margin-top:20px;margin-bottom:20px;"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterRafting_img2" /> 
					</xsl:attribute> 
				</img> 
		</a><br/>
     


<h3><b><xsl:value-of select="waterRafting_title3" /> </b></h3><br/>
<p>
	<xsl:value-of select="waterRafting_p5" /><br/><br/>
<xsl:value-of select="waterRafting_p6" />

	

</p>





<h3><b><xsl:value-of select="waterRafting_title4" />
</b></h3><br/>
<p>
	<xsl:value-of select="waterRafting_p7" />Duration: 1 day trip<br/><br/>
	<xsl:value-of select="waterRafting_p8" />


</p>

</div>
	   
	   
  </xsl:template>
</xsl:stylesheet>
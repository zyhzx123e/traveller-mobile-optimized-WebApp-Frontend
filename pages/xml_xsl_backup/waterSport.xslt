<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
 
  <xsl:template match="/waterSport">
  
    <div style="border-top: 2px solid whitesmoke;border-bottom: 2px solid whitesmoke;margin-top: 10px;">
    		<h3 style="    color: firebrick;font-family:cursive;" >
                <span> <xsl:value-of select="waterSport_title1" /> </span></h3>


			<p style="    color: darkolivegreen;" class="p1"> 

			<xsl:value-of select="waterSport_p1_1" />

            <a runat="server" href="~/pages/Home.aspx"> Malaysian Borneo </a>

				<xsl:value-of select="waterSport_p1_2" />
 
            <a runat="server" href="~/pages/borneoResort.aspx"> Sipadan </a>

			<xsl:value-of select="waterSport_p1_3" />
  
			</p><br/><br/>
			
<a runat="server" href="~/pages/Home.aspx"><xsl:value-of select="waterSport_title2" /></a> 

		<xsl:value-of select="waterSport_p2_1" />
            
<a runat="server" href="~/pages/Home.aspx"> Other activities </a>
            <xsl:value-of select="waterSport_p2_2" />
            <br/><br/>
			<br/>
			
			
	<div id="supportingText">
		<div id="explanation">
			<h3><span> <xsl:value-of select="waterSport_title3" /></span></h3>
			<p class="p1"> 

			<h4> <xsl:value-of select="waterSport_title3_sub1" /></h4><br/><br/>
<xsl:value-of select="waterSport_p3_1" />
   <br/><br/>
 
 <br/><a runat="server" href="~/pages/Home.aspx">
 <img runat="server" class="img"  alt="parasailing" title="parasailing"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p3_img1" /> 
					</xsl:attribute> 
					
				</img>  
		</a><br/><br/>
 
 <h4><xsl:value-of select="waterSport_title4" /></h4><br/><br/>
 <xsl:value-of select="waterSport_p4" />
 <br/><br/>
 
 <br/><a runat="server" href="~/pages/Home.aspx">
  <img runat="server" class="img" style="" alt="bananaboat" title="bananaboat"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p4_img1" /> 
					</xsl:attribute> 
				</img>  
	 	</a><br/><br/>
 
<h4><xsl:value-of select="waterSport_title5" /> </h4>
<br/><br/>
<xsl:value-of select="waterSport_p5" /> 
 <br/><br/>
 
 <br/><a runat="server" href="~/pages/Home.aspx">
  <img runat="server" class="img" style="" alt="boat-sailing" title="boat-sailing"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p5_img1" /> 
					</xsl:attribute> 
				</img> 
	 </a><br/><br/>
 
 
 <h4><xsl:value-of select="waterSport_title6"/></h4><br/><br/>

 <xsl:value-of select="waterSport_p6"/>
 <br/><br/>

<br/><a runat="server" href="~/pages/Home.aspx">
  <img runat="server" class="img" style="" alt="seakayaking" title="seakayaking"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p6_img1" /> 
					</xsl:attribute> 
				</img> 
		
		</a><br/><br/>
 
			
			
			 </p>
			
			
		</div>

		<div id="participation">
			<h3><span> <xsl:value-of select="waterSport_title7"/> </span></h3>
			<p class="p1"><span>
			
			<h4> <xsl:value-of select="waterSport_title7_sub1"/>  </h4><br/><br/>
			<xsl:value-of select="waterSport_p7"/> 
			
 <br/><br/>
 
 <br/><a runat="server" href="~/pages/Home.aspx">
   <img runat="server" class="img" style=""  alt="seakayaking" title="seakayaking"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p7_img1"/> 
					</xsl:attribute> 
				</img> 
	
	</a><br/><br/>
 
<h4><xsl:value-of select="waterSport_title8"/></h4><br/><br/>
<xsl:value-of select="waterSport_p8"/>  
 <br/><br/>
 
 <br/><a runat="server" href="~/pages/Home.aspx">
    <img runat="server" class="img" style="" alt="waterskiing" title="waterskiing"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p8_img1" /> 
					</xsl:attribute> 
				</img> 
				</a><br/><br/>
 
 <h4><xsl:value-of select="waterSport_title9" /> </h4><br/><br/>
 <xsl:value-of select="waterSport_p9" /> 
 <br/><br/>
 
 <br/><a runat="server" href="~/pages/Home.aspx">
    <img runat="server" class="img" style="" alt="wakeboarding" title="wakeboarding" > 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p9_img1" /> 
					</xsl:attribute> 
				</img> 
	 </a><br/><br/>
 
 <h4>	<xsl:value-of select="waterSport_title10" /> </h4><br/><br/>
 <xsl:value-of select="waterSport_p10" /> 
 <br/><br/>
 
 <br/><a runat="server" href="~/pages/Home.aspx">
  <img runat="server" class="img" style="" alt="fly fish" title="fly fish" > 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p10_img1" /> 
					</xsl:attribute> 
				</img> 
	 	</a><br/><br/>
			
			
			
			
			</span></p>
		</div>

		<div id="benefits">
			<h3><span><xsl:value-of select="waterSport_title11" /></span></h3>
			<p class="p1"><span>
			
			
			<h4><xsl:value-of select="waterSport_title11_sub1" /></h4><br/><br/>
<xsl:value-of select="waterSport_p11" />
		
		<br/><br/>
						
						<br/><a runat="server" href="~/pages/Home.aspx">
			 <img runat="server" class="img" style="" alt="kitesurfing" title="kitesurfing" > 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p11_img1" /> 
					</xsl:attribute> 
				</img> 
	
	</a><br/><br/>
						
			<h4>	<xsl:value-of select="waterSport_title12" /></h4><br/><br/>
<xsl:value-of select="waterSport_p12" /> 


						<br/><a runat="server" href="~/pages/Home.aspx">
			 <img runat="server" class="img" style="" alt="windsurfing" title="windsurfing"  > 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p12_img1" /> 
					</xsl:attribute> 
				</img> 
	
	</a><br/><br/>
						
			<h4><xsl:value-of select="waterSport_title13" /> </h4><br/><br/>
			
			<xsl:value-of select="waterSport_p13" /> 
		
		
                <br/><a runat="server" href="~/pages/Home.aspx">
					 <img runat="server" class="img"   alt="skydiving" title="skydiving"  style="margin-top:10px;"  > 
					<xsl:attribute name="src"> 
						<xsl:value-of select="waterSport_p13_img1" /> 
					</xsl:attribute> 
				</img> 
	
				</a>
			</span></p>
		</div>
	</div>
 </div>
      
    
	   
	   
  </xsl:template>
</xsl:stylesheet>
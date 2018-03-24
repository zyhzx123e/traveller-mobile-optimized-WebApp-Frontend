<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
 
  <xsl:template match="/rareSpecies">
  
   <div style="border-top: 2px solid whitesmoke;border-bottom: 2px solid whitesmoke;margin-top: 10px;" class="maintext">
			  <h2><span><xsl:value-of select="rareSpecies_title1" /> </span></h2>
			  <p>
			  <a runat="server" href="~/pages/borneoRainforest.aspx">Sabah(North Borneo)</a> 
			  <xsl:value-of select="rareSpecies_p1" /> 
              </p>
		<br/>


		<p> <a runat="server" href="~/pages/borneoRainforest.aspx">
		<img runat="server" class="img" style="float:left;margin-bottom:10px;margin-right:10px;" alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img1" /> 
					</xsl:attribute> 
				</img> 

		</a><xsl:value-of select="rareSpecies_p2" /> 
			 <br/><br/><br/>
			<xsl:value-of select="rareSpecies_p3" /> 
				
		</p> 

				 <br/>
                   <br/> <br/>
                  <p style="padding-top:50px;margin-top:50px;">
                      	  <br/> <br/>
			<h2><xsl:value-of select="rareSpecies_title2" /> </h2>
                       <a runat="server" href="~/pages/borneoRainforest.aspx">
	<img runat="server" class="img" style="float:right;    margin-bottom: 10px; margin-left: 10px; " alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img2" /> 
					</xsl:attribute> 
				</img> 
				
		</a><xsl:value-of select="rareSpecies_p4" /> 
			
            <a runat="server" href="~/pages/borneoRainforest.aspx">Borneo</a>
			<xsl:value-of select="rareSpecies_p5" /> 
              
                       <a runat="server" href="~/pages/borneoRainforest.aspx">Orang Utan</a> 
              <xsl:value-of select="rareSpecies_p6" /> 
                   
                       <a runat="server" href="~/pages/Home.aspx">Sandakan</a>
            <xsl:value-of select="rareSpecies_p7" /> 
              
                        <a runat="server" href="~/pages/borneoRainforest.aspx"> Danum Valley </a>
         <xsl:value-of select="rareSpecies_p8" /> 
                              </p>
	 
                  <p>
                      <a runat="server" href="~/pages/borneoRainforest.aspx">
				<img runat="server" class="img" style="margin-bottom: 10px;margin-right: 10px;float:left" alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img3" /> 
					</xsl:attribute> 
				</img> 	  

		</a>
			<xsl:value-of select="rareSpecies_p9" /> 
			          </p> 
		<br/><br/>
                  <br/><br/>

              <p style="margin-top:50px;">   
			<br/>
                    <a runat="server" href="~/pages/borneoRainforest.aspx">
		<img runat="server" class="img" style="  margin-bottom: 10px;margin-left: 10px;float:right;" alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img4" /> 
					</xsl:attribute> 
				</img> 	
				
		</a>
			<h2><xsl:value-of select="rareSpecies_title3" /> </h2>
<xsl:value-of select="rareSpecies_p10" />                  

                   <a runat="server" href="~/pages/Home.aspx">Borneo</a>. 
				   <xsl:value-of select="rareSpecies_p11" />   
              
                  <a runat="server" href="~/pages/Home.aspx">Sabah</a>
                    <xsl:value-of select="rareSpecies_p12" />   
              
              </p><br/><br/>
 <br/>

        
			 
		<br/>
                  
                  <p><a runat="server" href="~/pages/borneoRainforest.aspx">
				  <img runat="server" class="img" style="float:left;margin-bottom:10px;margin-right:10px;" alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img5" /> 
					</xsl:attribute> 
				</img> 
				
		</a> 
		
	<xsl:value-of select="rareSpecies_p13" /> 
	
                      <a runat="server" href="~/pages/borneoRainforest.aspx">Malayan</a>
<xsl:value-of select="rareSpecies_p14" /> 
	               
                  </p>
 <br/> <br/> <br/>
			
                  
                  <p style="margin-top:50px;">
                      <br/><br/>
                      <hr/>
                      <a runat="server" href="~/pages/borneoRainforest.aspx">
				<img runat="server" class="img" style="float:right;margin-bottom:10px;margin-left:10px;" alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img6" /> 
					</xsl:attribute> 
				</img> 
				
		</a>
			<h2><xsl:value-of select="rareSpecies_title4" /> </h2>
			<xsl:value-of select="rareSpecies_p15" /> 
			
                      <a runat="server" href="~/pages/MountKK.aspx">Mt Kinabalu</a> 
	<xsl:value-of select="rareSpecies_p16" /> 
	
	<br/>
		<br/>
                </p><br/><br/>
			
			
			
                  <p style="margin-top:30px;">
                      <br/>
                      <hr/>
			<h2><xsl:value-of select="rareSpecies_title5" /> </h2>
                       <a runat="server" href="~/pages/borneoRainforest.aspx">
				<img runat="server" class="img"  style="float:left;margin-bottom:10px;margin-right:10px;" alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img7" /> 
					</xsl:attribute> 
				</img> 

		</a>
		<xsl:value-of select="rareSpecies_p17" /> 

		<br/><br/>
 <br/>
		 </p>
 

                  <br/><br/>
                 <p style="margin-top:30px;"> <a runat="server" href="~/pages/borneoRainforest.aspx">
				 <img runat="server" class="img"  style="float:right;margin-bottom:10px;margin-left:10px;" alt="Borneo Rare Species" title="Borneo Rare Species"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img8" /> 
					</xsl:attribute> 
				</img> 
				
		</a> 	<xsl:value-of select="rareSpecies_p18" /> 

		
                 </p>
 <br/><br/>
 <br/>
		<br/>
                  
                  <p>
<xsl:value-of select="rareSpecies_p19" /> 

                  </p>
 <br/><br/>
<br/>
		<br/>
                  
                  
                  <p><a runat="server" href="~/pages/borneoRainforest.aspx">
				   <img runat="server" class="img" style="float:left;margin-bottom:10px;margin-right:10px;border-radius:10px;" alt="Borneo Rare Species" title="Borneo Rare Species" > 
					<xsl:attribute name="src"> 
						<xsl:value-of select="rareSpecies_img9" /> 
					</xsl:attribute> 
				</img> 

				
		</a> <xsl:value-of select="rareSpecies_p20" /> 
        </p>
			
	
			</div>
	   
	   
  </xsl:template>
</xsl:stylesheet>
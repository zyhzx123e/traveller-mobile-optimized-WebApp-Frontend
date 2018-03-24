<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->

  <xsl:param name="place_id"/>
  
		  
  <xsl:template match="/">
		<xsl:for-each select="/places/place">
       <xsl:if test="./place_id = $place_id">
	   
	       <p class="p_detail">          <b>Share-Info ID: </b> 
               <xsl:value-of select="place_id" /> <br />
          </p>    

           <p class="p_detail" style="font-family: calibri;font-size:25px ;padding-bottom:10px;margin-bottom:10px"> 
				<xsl:value-of select="place_title" /> <br />
				<img  id="img" style="width:70%;height:70%;border-radius:20px;border:5px outset orange;" alt="Traveller"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="place_img" /> 
					</xsl:attribute> 
				</img> 
				<br /><br />
 
           </p>
		   
           <p class="p_detail">  <b>Description: </b> 
			<xsl:value-of select="place_description" /> 
		   <br />
           </p>

		     <p class="p_detail">   <b>Address: </b> 
		 <xsl:value-of select="place_address" /> <br />
           </p>
		   
           <p class="p_detail">   <b>Longitude: </b> 
		 <xsl:value-of select="place_longitude" /> <br />
           </p>
                
          <p class="p_detail">  
		  <b> Latitude: </b> <xsl:value-of select="place_latitude" /> <br />
            </p>


      <p class="p_detail">      
	  <b> Time Uploaded: </b> <xsl:value-of select="place_time_upload" /> <br />
       </p>
             
              
         <p class="p_detail">      
               <b>Shared by: </b> 
             <span>
			 
			 <img  id="img_profile" style="float:right;height:50px;width:50px;border-radius:50%;border:3px double white" alt="Traveller"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="place_user_img" /> 
					</xsl:attribute> 
				</img> 
				<br />

            <xsl:value-of select="place_uid" />
                 </span><br />
         </p>
		 
		   <div style="cursor:pointer;padding:10px;" >
          <b>Liked by </b> <xsl:value-of select="place_like_count" />  <b> Person(s)</b> 
           </div >
	   
	   
	   
	   </xsl:if>
     
	  
	  
    </xsl:for-each>
   
  </xsl:template>
</xsl:stylesheet>
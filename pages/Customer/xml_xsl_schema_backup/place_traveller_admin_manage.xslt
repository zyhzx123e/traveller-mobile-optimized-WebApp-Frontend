<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->

  <xsl:param name="place_id"/>
   
		  
  <xsl:template match="/">
		<xsl:for-each select="//place">
       <xsl:if test="./place_id = $place_id">
	   
	     
	   
	   
	       <p class="p_detail">          <b>Share-Info ID: </b> 
				 <xsl:value-of select="place_id" /> 
              <br />
          </p>    

           <p class="p_detail" style="font-family: calibri;font-size:25px ;padding-bottom:10px;margin-bottom:10px"> <b>Title of Post: </b> 
			<input runat="server" type="text"   style="border-radius:10px;width:90%;min-height:25px;margin:10px;padding:5px;font-size:13px;" id="txt_item_title">
				<xsl:attribute name="value">
					 <xsl:value-of select="place_title" /> 
				</xsl:attribute>
			</input>
		   <br />
				<img runat="server" id="img" style="width:70%;height:70%;border-radius:20px;border:5px outset orange;" alt="Traveller"> 
					<xsl:attribute name="src"> 
						<xsl:value-of select="place_img" /> 
					</xsl:attribute> 
				</img> 
				
             <asp:FileUpload CssClass="btn-success" style="width: 95%;padding: 10px;margin-left:5px;margin-right:20px;font-size: 15px;border-radius: 20px;border: 5px double;background-color: chocolate;opacity: .9;" ID="FileUpload1" runat="server" />  
                 <asp:Label ID="lblCurrentFile" runat="server"></asp:Label> 
      
                <asp:HiddenField ID="HiddenField1" runat="server" />
				 
 
           </p>
		   
		      <p class="p_detail">  <b>Place Name: </b> 
		   	<input runat="server" type="text" rows="5"  style="border-radius:10px;width:90%;height:40px;margin:10px;padding:5px;font-size:12px;overflow:scroll;" id="txt_item_name">
				<xsl:attribute name="value">
					 <xsl:value-of select="place_name" /> 
				</xsl:attribute>
			</input>
			 
		   <br />
           </p>
		   
           <p class="p_detail">  <b>Description: </b> 
		   	<input runat="server" type="text" rows="5"  style="border-radius:10px;width:90%;height:40px;margin:10px;padding:5px;font-size:12px;overflow:scroll;" id="txt_item_desc">
				<xsl:attribute name="value">
					 <xsl:value-of select="place_description" /> 
				</xsl:attribute>
			</input>
			 
		   <br />
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
		   <p class="p_detail">      
	  <b>  Time Committed:  </b> <xsl:value-of select="place_time_upload" /> <br />
       </p>
		   
		 
		<div style="cursor:pointer;padding:10px;" >
          <b>Liked by </b> <xsl:value-of select="place_like_count" />  <b> Person(s)</b> 
           </div >
		  

			
	   
	   
	   
	   </xsl:if>
     
	  
	  
    </xsl:for-each>
   
  </xsl:template>
</xsl:stylesheet>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:asp="remove">
  <xsl:output method="xml" indent="yes" encoding="utf-8" omit-xml-declaration="yes"/>
<!-- Edited by zhang yu hao -->
  <xsl:param name="stuff_id"/>
  <xsl:param name="current_uid"/>
  <xsl:template match="/"><hr/>
	    <div id="comment_xsl_block" style="padding:10px; border-radius:15px;" >
		   <div id="comment_title" style="padding:10px;background-color:cadetblue;color:white; border-radius:20px 20px 0px 0px">
		   <h3 style="font-size:25px;font-family:cursive;">Comment about this</h3>
		   </div>
		   <xsl:for-each select="/stuffs_comments/stuffs_comment">
			   <xsl:if test="./stuff_id = $stuff_id">
					<xsl:choose>
						<xsl:when test="./stuff_comment_uid = $current_uid">
							<div class="container_comment darker">
								<div class="profile_div img_right">
									<img border="0" style="width:100%;" alt="Traveller"> 
										<xsl:attribute name="src"> 
											<xsl:value-of select="stuff_comment_user_img" /> 
										</xsl:attribute> 
									</img> 
									<span>
										<xsl:value-of select="stuff_comment_uid" /> 
									</span>
								</div>
								<p style="padding-top:10px;">
										<xsl:value-of select="stuff_comment_text" /> 
								</p>
								<span class="time-left">
										<xsl:value-of select="stuff_comment_time" /> 
								</span>
						    </div>
						</xsl:when>
						<xsl:otherwise>
							<div class="container_comment">
								<div class="profile_div img_left">
									<img border="0" style="width:100%;" alt="Traveller"> 
										<xsl:attribute name="src"> 
												<xsl:value-of select="stuff_comment_user_img" /> 
										</xsl:attribute> 
									</img> 
									<span>
										<xsl:value-of select="stuff_comment_uid" /> 
									</span>
								</div>
								<p style="padding-top:10px;">
									<xsl:value-of select="stuff_comment_text" /> 
								</p>
								<span class="time-right">
									<xsl:value-of select="stuff_comment_time" /> 
								</span>
							</div>
						</xsl:otherwise>
					</xsl:choose>
			    </xsl:if>
			</xsl:for-each>
		</div>
	   
	   
  </xsl:template>
</xsl:stylesheet>
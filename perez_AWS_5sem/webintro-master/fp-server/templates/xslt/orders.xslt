<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:key name="orders-by-category" match="order" use="@category" />

    <xsl:template match="/">
        <div>
            <h3>Stats</h3>
                <!-- //student[count(. |  key('students-by-group', @group)[1] ) = 1 -->
                <!-- //student[@group=9] -->
                <h4>Total orders:<xsl:value-of select="count(//order)"/></h4>

                <xsl:apply-templates select="//order[generate-id(.) = generate-id(key('orders-by-category', @category)[1] )]"/>
        </div>
    </xsl:template>

    <xsl:template match="order">
        <h5>Tea <xsl:value-of select="@category"/></h5>
        <h6>Total: <xsl:value-of select="count(//order[@category = current()/@category])"/></h6>
        <ul>
            <xsl:apply-templates select="key('orders-by-category', @category)" mode="grouping"/>
        </ul>
    </xsl:template>

    <xsl:template match="order" mode="grouping">
        <li><xsl:value-of select="@date"/> -
            <xsl:value-of select="@product"/>
        </li>
    </xsl:template>

</xsl:stylesheet>
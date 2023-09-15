<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <html>
            <body>
                <h1>Timetable</h1>
                <p>The best events count: <xsl:value-of select="count(//event[@rating > 2])"/></p>
                <table>
                    <xsl:apply-templates select="//event"/>
                </table>
            </body>
        </html>
    </xsl:template>
    <xsl:template match="event">
        <tr><td><xsl:value-of select="@place"/></td><td>Time:<xsl:value-of select="@time"/></td><td>Rating:<xsl:value-of select="@rating"/></td></tr>
    </xsl:template>
</xsl:stylesheet>

<?xml version="1.0"?>
<xsl:stylesheet
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:xhtml="http://www.w3.org/1999/xhtml"
        xmlns:atom="http://www.w3.org/2005/Atom"
        xmlns="http://www.w3.org/1999/xhtml"
        version="1.0">

    <xsl:import href="html5.xslt"/>
 
    <xsl:key name="entry-by-category" match="atom:entry" use="atom:category[1]/@term" />

    <xsl:template match="/atom:feed">
       <html>
                <head>
                    <title><xsl:value-of select="atom:title" /></title>
                    <link rel="alternate" type="application/atom+xml" href="{atom:link[@rel='self']/@href}" />
                    <link rel="Stylesheet" href="style.css"/>
                </head>
                <body id="feed">
                    <xsl:apply-templates select="atom:entry[generate-id(.) = generate-id(key('entry-by-category', atom:category/@term)[1])]">
                        <!-- atom:entry[count(. | key('entry-by-category', atom:category/@term)[1]) = 1] -->
                        <xsl:sort select="atom:category/@term" />
                    </xsl:apply-templates>
                </body>
            </html>
    </xsl:template>

    <xsl:template match="atom:entry">
        <h1><xsl:value-of select="atom:category/@term" /></h1>
        <ul>
            <xsl:for-each select="key('entry-by-category', atom:category/@term)">
                <xsl:sort select="atom:updated" order="descending"/>
                <li>
                    <a  href="{{atom:link/@href}}">
                        <span><xsl:value-of select="atom:title" /></span></a>
                        <xsl:value-of select="concat(' ',atom:summary)" />

                </li>
            </xsl:for-each>
        </ul>
    </xsl:template>
</xsl:stylesheet>
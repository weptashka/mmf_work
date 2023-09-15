<?xml version="1.0"?>
<xsl:transform
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:html="http://www.w3.org/1999/xhtml"
    xmlns="http://www.w3.org/1999/xhtml"
    version="1.0"
>

    <xsl:strip-space elements="html:html html:head html:body html:table html:thead html:tbody html:tfoot"/>

    <xsl:output method="xml" version="1.0" encoding="UTF-8"
                doctype-public="-//W3C//DTD XHTML 1.1//EN"
                doctype-system="http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd"
                indent="no"
                media-type="application/xhtml+xml" />

    <xsl:template match="html:html">
        <xsl:text disable-output-escaping="yes">&lt;!DOCTYPE html&gt;&#xa;</xsl:text>
        <xsl:apply-imports/>
    </xsl:template>

</xsl:transform>

export const extractXmlParam = (
  xmlData: any,
  methodName: string,
  paramName: string,
) =>
  xmlData['soapenv:envelope']['soapenv:body'][0][
    `web:${methodName.toLowerCase()}`
  ][0][`web:${paramName.toLowerCase()}`][0];

export const generateXmpResponse = (
  entity: any,
  methodName: string,
  responseField: string,
) => {
  const params = Object.entries(entity)
    .map(([key, value]) => `<web:${key}>${value}</web:${key}>`)
    .join('\n');

  return `<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:web="http://example.com/petStore">
            <soapenv:Body>
              <web:${methodName}Response>
                <web:${responseField}>
                  ${params}
                </web:${responseField}>
              </web:${methodName}Response>
            </soapenv:Body>
          </soapenv:Envelope>`;
};

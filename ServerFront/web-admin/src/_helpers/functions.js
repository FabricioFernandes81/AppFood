export function parseISO3166(code) {
  const regex = /^([A-Z]{2})-([A-Z0-9]{1,3})$/i;

  if (typeof code !== "string") return { countryCode: "", stateCode: "" };

  const match = code.match(regex);

  if (match) {
    const [, countryCode, stateCode] = match;
    return { countryCode, stateCode };
  }

  return { countryCode: "", stateCode: "" };
}

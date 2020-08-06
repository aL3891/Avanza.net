# Avanza.net

A .net port of [Filip Hallqvists node wrapper](https://github.com/fhqvst/avanza) for the unofficial Avanza API. Please note that this is only a proof of concept, hence not meant to be used by anyone.

This project is also not affiliated with Avanza Bank AB in any way. The underlying API can be taken down or changed without warning at any point in time.

## Limitations

Several features are not yet available, such as websocket support. Also the datamodel is missing some properties

## Getting a TOTP Secret

**NOTE: Since May 2018 two-factor authentication is used to log in.**

Here are the steps to get your TOTP Secret:

0. Go to Mina Sidor > Profil > Sajtinställningar > Tvåfaktorsinloggning and click "Återaktivera". (*Only do this step if you have already set up two-factor auth.*)
1. Click "Aktivera" on the next screen.
2. Select "Annan app för tvåfaktorsinloggning".
3. Click "Kan du inte scanna QR-koden?" to reveal your TOTP Secret.
5. Finally, run the test called `TotpTest` to generate an initial code.
6. Done! 

## LICENSE

MIT license. See the LICENSE file for details.

## RESPONSIBILITIES

The author of this software is not responsible for any indirect damages (foreseeable or unforeseeable), such as, if necessary, loss or alteration of or fraudulent access to data, accidental transmission of viruses or of any other harmful element, loss of profits or opportunities, the cost of replacement goods and services or the attitude and behavior of a third party.
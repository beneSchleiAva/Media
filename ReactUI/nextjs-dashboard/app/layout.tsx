import '@/app/ui/global.css';
import { inter } from '@/app/ui/fonts';
import OrderCustomizerLogo from './ui/OrderCustomizerLogo';

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html lang="en">
      <body className={`${inter.className} antialiased`}>
        <div className="h-screen">
          <div className="flex flex-col p-4">
            <div className="flex items-end rounded-lg bg-blue-900  p-4 md:h-40">
              <OrderCustomizerLogo />
            </div>
            <div className="m-0 p-0 flex flex-col gap-4 md:flex-row">
              {children}
            </div>
          </div>
        </div>
      </body>
    </html>
  );
}

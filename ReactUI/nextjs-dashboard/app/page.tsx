"use client";
import OrderCustomizerLogo from '@/app/ui/OrderCustomizerLogo';
import { ArrowRightIcon } from '@heroicons/react/24/outline';
import Link from 'next/link';
import Image from 'next/image';
import React from 'react';
import { MsalProvider } from "@azure/msal-react";
import { PublicClientApplication } from "@azure/msal-browser";
import msalConfig from "./msal.config";

const msalInstance = new PublicClientApplication(msalConfig);

import SideNavigation from './ui/dashboard/sidenav';
import { useMsal } from "@azure/msal-react";

const LoginButton = () => {
  const { instance } = useMsal();

  const handleLogin = () => {
    instance.loginRedirect();
  };

  return <button onClick={handleLogin}>Login</button>;
};

export default function Page() {
  return (
  <div>
    <MsalProvider instance={msalInstance}>
    <LoginButton></LoginButton>
    <div className="flex flex-col gap-2 rounded-lg bg-gray-100 p-8 md:w-3/10 md:px-30">
      <SideNavigation />
    </div>  
  </MsalProvider>

    </div>

  );
}

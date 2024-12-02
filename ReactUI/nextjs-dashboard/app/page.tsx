import OrderCustomizerLogo from '@/app/ui/OrderCustomizerLogo';
import { ArrowRightIcon } from '@heroicons/react/24/outline';
import Link from 'next/link';
import Image from 'next/image';
import React from 'react';
import SideNavigation from './ui/dashboard/sidenav';

export default function Page() {
  return (
    <React.Fragment>
      <div className="flex flex-col gap-2 rounded-lg bg-gray-100 p-8 md:w-3/10 md:px-30">
        <SideNavigation />
      </div>
    </React.Fragment>
  );
}

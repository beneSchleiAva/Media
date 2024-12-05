'use client';
import Link from 'next/link';

import { PowerIcon } from '@heroicons/react/24/outline';
import React from 'react';
import { useRouter } from 'next/navigation'

import {
  UserGroupIcon,
  HomeIcon,
  DocumentDuplicateIcon,
} from '@heroicons/react/24/outline';
import clsx from 'clsx';
import { usePathname } from 'next/navigation';
import { Button } from '@mui/material';

// Map of links to display in the side navigation.
// Depending on the size of the application, this would be stored in a database.
const links = [
  { name: 'Home', href: '/ ', icon: HomeIcon },
  {
    name: 'Orders',
    href: '/dashboard/orders',
    icon: DocumentDuplicateIcon,
  },
  { name: 'Products', href: '/dashboard/products', icon: UserGroupIcon },
  { name: 'Sign In', href: '/signin', icon: PowerIcon },
  { name: 'Sign Out', href: '/signout', icon: PowerIcon },
];

export default function SideNavigation() {
  const pathname = usePathname();
  const router = useRouter()
  return (
    <div className="flex flex-col gap-4 pt-4 p-4
			 items-center justify-start
             bg-gray-100">

      {links.map((link) => {
        const LinkIcon = link.icon;
        return (
          <Button key={link.name}
            className={clsx(
              'w-40 border-dashed border-2 border-indigo-600 flex h-[48px] grow items-center justify-center gap-2 rounded-md bg-gray-50 p-3 text-sm font-medium hover:bg-sky-100 hover:text-blue-600 md:flex-none md:justify-start md:p-2 md:px-3',
              {
                'bg-sky-100 text-blue-600': pathname === link.href,
              },
            )} type="button" onClick={() => router.push(link.href)}>
            {link.name}
          </Button>
        );
      })}
    </div>)
};



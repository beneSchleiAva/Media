"use client";
import SideNavigation from '@/app/ui/dashboard/sidenav';
 
export default function Layout({ children }: { children: React.ReactNode }) {
  return (
    <div className="h-full flex h-screen flex-col md:flex-row md:overflow-hidden">
      <div className="w-full flex-none md:w-64">
        <SideNavigation />
      </div>
      <div >{children}</div>
    </div>
  );
}